/*
 * known issues to be solved: encoder being full on object add
 * sort out how we're going to track the tracker
 *
 *
 *
 */

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Networking;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class NetworkManager : MonoBehaviour {

    #region Inspector_vars
    [Header("Server Setttings")]
    public int MAX_CONNECTIONS = 1;
    public string connection_ip = "137.205.112.42";
    public int connection_port = 9090;

    [Header("Spawning")]
    public GameObject[] spawnables = new GameObject[0];

    //todo
    [Header("Channels")]
	private int myReliableChannelId;
	private int myUnreliableChannelId;
	private int myUpdateChannelId;
    private int myStateChannelId;

    [Header("VR")]
	public GameObject leftController;
	public GameObject rightController;
    public GameObject Camera;
    public GameObject spooker;
    public GameObject throwBall;
    public GameObject wallDemo;
    public GameObject tracker;

    #endregion

    #region Global_vars
    private int socketId;
    public static bool serverHosted = false;
    public bool isHost = true;
	private bool networkInitialised = false;
    private int clientsConnected = 0;
    private int[] clientIds;

    private int hostId;

    #endregion

    #region Global_structures
    //dictionary to identify individual objects, may not be super necessary eventually
    public Dictionary<int, GameObject> watchList = new Dictionary<int, GameObject>();
    public Dictionary<String, int> spawnAssets = new Dictionary<String, int>();
    public Dictionary<int, GameObject> networkedObjects = new Dictionary<int, GameObject>();


    #endregion

    #region Unity Functions
    //value to check when we should send a new batch of updates
    void Awake(){
        for(int i = 0; i < spawnables.Length; i++){
            String assetId = NetworkTransport.GetAssetId(spawnables[i]);
            spawnAssets.Add(assetId, i);
        }
    }

    #region Start

	void Start () {
        if(isHost){
            clientIds = new int[MAX_CONNECTIONS];
        }

        if (!networkInitialised){
            NetworkTransport.Init();
            Debug.Log("Host Started");
            ConnectionConfig config = new ConnectionConfig();
            config.SendDelay = 0;
            myReliableChannelId = config.AddChannel(QosType.Reliable);
            myUpdateChannelId = config.AddChannel(QosType.StateUpdate);
            myStateChannelId = config.AddChannel(QosType.StateUpdate);
            HostTopology topology = new HostTopology(config, MAX_CONNECTIONS);
            socketId = NetworkTransport.AddHost(topology, connection_port);
            Debug.Log("Socket ID: " + socketId);
            networkInitialised = true;/* TODO For the time being! */
        }

        //initialise timer
	}

    #endregion


    #region Update
	void Update () {

        if (networkInitialised)
        {
            int recHostId;
            int connectionId;
            int channelId;
            byte[] recBuffer = new byte[1024]; //Info for actions to occur
            int bufferSize = 1024;
            int dataSize;
            byte error;
            NetworkEventType recData = NetworkTransport.Receive(out recHostId, out connectionId, out channelId, recBuffer, bufferSize, out dataSize, out error);
            switch (recData)
            {
                case NetworkEventType.Nothing:
                    //because nothing is happening, let's try and update the AR on positions
                    if(isHost){
                        SendEnemyUpdate();
                    }
                    break;
                case NetworkEventType.ConnectEvent: //AR connects
                    Debug.Log("Connection request from id: " + connectionId + " Received");
                    if(isHost){
                        HandleConnect(connectionId);
                    }else{
                        InvokeRepeating("SendEnemyDamage", 0.0f, 0.1f);
                    }

                    break;
                case NetworkEventType.DataEvent:
                    Debug.Log("Data Received");
                    DemoCoder decoder = new DemoCoder(recBuffer);
                    for(int i = 0; i < decoder.getCount(); i++){
                        switch (decoder.GetType(i)){
                            case (byte)MessageIdentity.Type.Initialise:
                                HandleClientSpawn(decoder.GetAssetID(i),decoder.GetID(i),decoder.GetPosition(i), decoder.GetRotation(i), decoder.GetVelocity(i));
                                break;
                            case (byte)MessageIdentity.Type.Update:
                                HandleUpdate(decoder.GetID(i), decoder.GetPosition(i), decoder.GetRotation(i));
                                break;
                            case (byte)MessageIdentity.Type.Spawn:
                                HandleClientSpawn(decoder.GetAssetID(i), decoder.GetID(i), decoder.GetPosition(i), decoder.GetRotation(i), decoder.GetVelocity(i));
                                break;
                            case (byte)MessageIdentity.Type.Remove:
                                HandleRemove(decoder.GetID(i));
                                break;
                            case (byte)MessageIdentity.Type.Request:
                                HandleSpawnRequest(decoder.GetAssetID(i), decoder.GetPosition(i), decoder.GetRotation(i), decoder.GetVelocity(i));
                                break;
                            case (byte)MessageIdentity.Type.DamageEnemy:
                                HandleDamageEnemy(decoder.GetID(i), decoder.GetEnemyDamage(i));
                                break;
                            case (byte)MessageIdentity.Type.EnemyUpdate:
                                HandleEnemyUpdate(decoder.GetID(i), decoder.GetEnemyHealth(i), decoder.GetPosition(i), decoder.GetRotation(i));
                                break;
                            case (byte)MessageIdentity.Type.ARUpdate:
                                //update position of AR mans
                                break;
                            case (byte)MessageIdentity.Type.PortalUpdate:
                                break;
                        }
                    }
                    break;
                case NetworkEventType.DisconnectEvent: //AR disconnects
                    clientsConnected--;
                    networkInitialised = false;
					Debug.Log("Disconnect Received");
                    break;
            }
            if (isConnection()) {
                //also send the transform of the tracker over a state channel
                if(tracker){
                    Debug.Log("Sending tracker info");
                    DemoCoder trackerEncode = new DemoCoder(1024);
                    trackerEncode.addSerial(6, -1, -1, tracker.transform);
                    byte error2;
                    foreach(int id in clientIds){
                        NetworkTransport.Send(socketId, id, myStateChannelId, trackerEncode.getArray(), 1024, out error2);
                    }
                }


            }
        }
	}

    #endregion

    #endregion

    /* So, I figure that this might be necessary for this network manager, if it wants to work for AR as well */
    #region Request Functions
    public bool RequestSpawn(int assetId, Transform transform, int hostId){
        byte error;
        DemoCoder encoder = new DemoCoder(50);
        encoder.addSerial((Byte)MessageIdentity.Type.Request, -1, assetId, transform);
        NetworkTransport.Send(socketId, hostId, myReliableChannelId, encoder.getArray(), 1024, out error);
        return true;
    }

    public void RequestConnect(){
        if(!isHost){
            byte error;
            Debug.Log("Attempting to connect to <" + connection_ip + "> on port <" + connection_port + ">");
            int hostId = NetworkTransport.Connect(socketId, connection_ip, connection_port, 0, out error);
            if(error == (byte)NetworkError.Ok){
                //return true;
            }
        }
        //return false;
    }

    #endregion

    #region Send Functions
    public bool SendUpdate(int connectionId){
        if (isConnection()/* && Input.GetKeyDown(KeyCode.U)*/) {
        Debug.Log("Trying to update client on " + watchList.Count + " objects");

            //we have switched to a watch list instead of a queue
            //since this is a dictionary element we need to iterate through
            //using foreach and then referring to the id and Gameobject as
            //kvp.Key and kvp.Value
            DemoCoder encoder = new DemoCoder(1024);
            bool empty = true;
            foreach(KeyValuePair<int, GameObject> kvp in watchList){
                //Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                empty = false;
                if (encoder.isFull()){
                    break;
                }
                //int id = gameObject.GetComponent<NetworkIdentity>().getObjectId();
                encoder.addSerial((Byte)MessageIdentity.Type.Update, kvp.Key, -1, kvp.Value.transform);
            }

            if(!empty){
                byte error3;
                NetworkTransport.Send(socketId, connectionId, myUpdateChannelId, encoder.getArray(), 1024, out error3);
                encoder = new DemoCoder(1024);
            }
        }

        return true;
    }

    public void SendSpawn(GameObject gameObject) {
        byte error2;
        DemoCoder encoder = new DemoCoder(50);
        int objectId = gameObject.GetComponent<NetworkIdentity>().getObjectId();
        String assetId = NetworkTransport.GetAssetId(gameObject);
        int assetIdNum;
        spawnAssets.TryGetValue(assetId, out assetIdNum);
        encoder.addSerial((byte)MessageIdentity.Type.Spawn, objectId, assetIdNum, gameObject.transform);
        foreach(int id in clientIds){
            NetworkTransport.Send(socketId, id, myReliableChannelId, encoder.getArray(), 50, out error2);
        }
    }

    public void SendRemove(int objectId){
        byte error2;
        DemoCoder encoder = new DemoCoder(50);
        encoder.addSerial((byte)MessageIdentity.Type.Remove, objectId, -2, null);
        foreach(int id in clientIds){
            NetworkTransport.Send(socketId, id, myReliableChannelId, encoder.getArray(), 50, out error2);
        }
    }

    public void SendEnemyUpdate(){
        if (isConnection()/* && Input.GetKeyDown(KeyCode.U)*/) {
            Debug.Log("Trying to update client on " + watchList.Count + " objects");

            //we have switched to a watch list instead of a queue
            //since this is a dictionary element we need to iterate through
            //using foreach and then referring to the id and Gameobject as
            //kvp.Key and kvp.Value
            DemoCoder encoder = new DemoCoder(1024);
            bool empty = true;
            foreach(KeyValuePair<int, GameObject> kvp in watchList){
                //Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                empty = false;
                if (encoder.isFull()){
                    break;
                }
                //int id = gameObject.GetComponent<NetworkIdentity>().getObjectId();
                EnemyHealth eh = kvp.Value.GetComponent<EnemyHealth>();
                if (eh != null) {
                    encoder.addEnemyUpdate(kvp.Key, eh.GetHealth(), kvp.Value.transform);
                } else {
                    Debug.LogError("Failed to get the Enemy Health for id " + kvp.Key);
                    encoder.addEnemyUpdate(kvp.Key, -1, kvp.Value.transform);
                }

            }

            if(!empty){
                byte error3;
                foreach(int clientId in clientIds){
                    NetworkTransport.Send(socketId, clientId, myUpdateChannelId, encoder.getArray(), 1024, out error3);
                }
            }
        }
    }

    public void SendEnemyDamage(){
        DemoCoder encoder = new DemoCoder(1024);
        foreach(EnemyHealth enemy in GameObject.FindObjectsOfType<EnemyHealth>()){
            if(enemy.transientHealthLoss > 0){
                int id = enemy.GetComponent<NetworkIdentity>().getObjectId();
                encoder.addEnemyDamage(id, enemy.transientHealthLoss);
            }
        }
        byte error;
        NetworkTransport.Send(socketId, hostId, myReliableChannelId, encoder.getArray(), 1024, out error);
    }

    #endregion

    #region Handler Functions

    public bool HandleUpdate(int id, Vector3 pos, Quaternion rot){
        GameObject instance;
        networkedObjects.TryGetValue (id, out instance);
        instance.transform.position = pos;
        instance.transform.rotation = rot;
        return true;
    }
    public bool HandleConnect(int connectionId){
        //these first 2 lines need rectifying due to obvious errors
        clientIds[clientsConnected] = connectionId;
        clientsConnected++;
        byte error2;
        DemoCoder encoder = new DemoCoder(1024);
        NetworkIdentity[] networkIdentities = getNetworkIdentities();
        foreach(NetworkIdentity identity in networkIdentities){
            int assetid;
            spawnAssets.TryGetValue(NetworkTransport.GetAssetId(identity.gameObject), out assetid);
            encoder.addSerial((Byte)MessageIdentity.Type.Initialise, identity.getObjectId(), assetid, identity.gameObject.transform);
            if(encoder.isFull()){
                NetworkTransport.Send(socketId, connectionId, myReliableChannelId, encoder.getArray(), 1024, out error2);
                encoder = new DemoCoder(1024);
            }
        }
        NetworkTransport.Send(socketId, connectionId, myReliableChannelId, encoder.getArray(), 1024, out error2);
        return true;
    }

    private void HandleClientSpawn(int assetId, int objectId, Vector3 pos, Quaternion rot, Vector3 vel){
        GameObject instance = Instantiate(spawnables[assetId], pos, rot);
        if(!isHost){
            instance.GetComponent<NetworkIdentity>().setObjectId(objectId);
        }

    }

    private void HandleSpawnRequest(int assetId, Vector3 pos, Quaternion rot, Vector3 vel){
        GameObject instance = Instantiate(spawnables[assetId], pos, rot);
    }


    private void HandleRemove(int id){
        GameObject instance;
        networkedObjects.TryGetValue(id, out instance);
        Destroy(instance);
    }

    private void HandleDamageEnemy(int id, int damage){
        GameObject gameObject;
        networkedObjects.TryGetValue(id, out gameObject);
        //ALTER HEALTH OF ENEMY MAN
        EnemyHealth eh = gameObject.GetComponent<EnemyHealth>();
        if (eh != null) {
            //just use damage, that's fine
            eh.Damage(damage);
        } else {
            Debug.LogError("Couldn't find enemy health tracking from network id" + id);
        }
    }

    private void HandleEnemyUpdate(int id, int health, Vector3 pos, Quaternion rot){
        GameObject instance;
        networkedObjects.TryGetValue (id, out instance);
        EnemyHealth eh = instance.GetComponent<EnemyHealth>();
        if (eh != null) {
            //keeps track of networked and local at the same time
            int currentHealth = eh.GetHealth();
            int networkedHealth = health - eh.transientHealthLoss;
            //don't reset transient, since this may still need to be transmitted
            eh.SetHealth(Math.Min(currentHealth, networkedHealth));
        } else {
            Debug.LogError("Couldn't find enemy health tracking from network id" + id);
        }
        instance.transform.position = pos;
        instance.transform.rotation = rot;
    }

    #endregion

    #region Utility Functions

    private NetworkIdentity[] getNetworkIdentities(){
        return GameObject.FindObjectsOfType<NetworkIdentity>();
    }

    public bool isConnection(){
        return clientsConnected > 0;
    }

    #endregion

    #region Custom Structures



    //class for defining message ID's
    public class MessageIdentity : MonoBehaviour {

        public enum Type : byte{
            Initialise = 0,
            Update = 1,
            Spawn = 2,
            Remove = 3,
            Request = 4,
            EnemyUpdate = 5,
            DamageEnemy = 6,
            ARUpdate = 7,
            PortalUpdate = 8,
            HealPlayer = 9
        }
    }

    #endregion

}
