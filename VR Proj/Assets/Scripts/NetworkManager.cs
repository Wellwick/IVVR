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

    public GameObject playerModel;

    public GameObject VREye;

    //todo
    [Header("Channels")]
	private int myReliableChannelId;
	private int myUnreliableChannelId;
	private int myUpdateChannelId;
    private int myStateChannelId;
    //private int myPingChannelId;

    [Header("VR")]
	public GameObject leftController;
	public GameObject rightController;
    public GameObject tracker;

    [Header("Debug")]
    //public bool showPing = false;

    #endregion

    #region Global_vars
    private int socketId;
    public static bool serverHosted = false;
    public bool isHost = true;
	private bool networkInitialised = false;
    private int clientsConnected = 0;

    private int hostId;
    //private bool pingSent = false;
    //private float pingTime = Time.time;

    #endregion

    #region Global_structures
    //dictionary to identify individual objects, may not be super necessary eventually
    public Dictionary<int, GameObject> watchList = new Dictionary<int, GameObject>();
    public Dictionary<String, int> spawnAssets = new Dictionary<String, int>();
    public Dictionary<int, GameObject> networkedObjects = new Dictionary<int, GameObject>();
    public Dictionary<int, GameObject> ARPlayers = new Dictionary<int, GameObject>();


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

        if (!networkInitialised){
            NetworkTransport.Init();
            Debug.Log("Host Started");
            ConnectionConfig config = new ConnectionConfig();
            config.SendDelay = 0;
            myReliableChannelId = config.AddChannel(QosType.Reliable);
            //myPingChannelId = config.AddChannel(QosType.Reliable);
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
            /*
            if(channelId == myPingChannelId){
                if(pingSent){
                    Debug.Log(pingTime - Time.time);
                    pingTime = Time.time;
                }
                SendPing(connectionId);
            }
            */
            switch (recData)
            {
                case NetworkEventType.Nothing:
                    //because nothing is happening, let's try and update the AR on positions
                    if(isHost){
                        SendGeneralUpdate();
                        SendVRBroadcast();
                    }
                    break;
                case NetworkEventType.ConnectEvent: //AR connects
                    Debug.Log("Connection request from id: " + connectionId + " Received");
                    if(isHost){
                        HandleConnect(connectionId);
                        //SendPing(connectionId);
                    }else{
                        InvokeRepeating("SendEnemyDamage", 0.1f, 0.1f);
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
                            case (byte)MessageIdentity.Type.GeneralUpdate:
                                HandleGeneralUpdate(i, decoder);
                                break;
                            case (byte)MessageIdentity.Type.ARUpdateVR:
                                HandleARUpdateVR(connectionId, decoder.GetPosition(i), decoder.GetRotation(i), decoder.GetShootEnum(i));
                                break;
                            case (byte)MessageIdentity.Type.VRUpdateAR:
                                HandleVRUpdateAR(decoder.GetPosition(i), decoder.GetRotation(i));
                                break;
                            case (byte)MessageIdentity.Type.HealPlayer:
                                HandleHealPlayer(decoder.GetPlayerHeal(i));
                                break;


                        }
                    }
                    break;
                case NetworkEventType.DisconnectEvent: //AR disconnects
                    HandleClientDisconnect(connectionId);
					Debug.Log("Disconnect Received");
                    break;
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
        foreach(KeyValuePair<int, GameObject> kvp in ARPlayers){
            NetworkTransport.Send(socketId, kvp.Key, myReliableChannelId, encoder.getArray(), 50, out error2);
        }
    }

    public void SendRemove(int objectId){
        byte error2;
        DemoCoder encoder = new DemoCoder(50);
        encoder.addSerial((byte)MessageIdentity.Type.Remove, objectId, -2, null);
        foreach(KeyValuePair<int, GameObject> kvp in ARPlayers){
            NetworkTransport.Send(socketId, kvp.Key, myReliableChannelId, encoder.getArray(), 50, out error2);
        }
    }

    public void SendGeneralUpdate(){
        if (isConnection()/* && Input.GetKeyDown(KeyCode.U)*/) {
            Debug.Log("Trying to update client on " + watchList.Count + " objects");

            //we have switched to a watch list instead of a queue
            //since this is a dictionary element we need to iterate through
            //using foreach and then referring to the id and Gameobject as
            //kvp.Key and kvp.Value
            DemoCoder encoder = new DemoCoder(1024);
            Henge henge = GameObject.Find("Henge").GetComponent<Henge>();
            encoder.addPortal(henge.GetRuneState(), henge.transform);
            // We have removed empty, because we are always sending the henge information
            foreach(KeyValuePair<int, GameObject> kvp in watchList){
                //Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                
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

            byte error3;
            foreach(KeyValuePair<int, GameObject> kvp in ARPlayers){
                NetworkTransport.Send(socketId, kvp.Key, myUpdateChannelId, encoder.getArray(), 1024, out error3);
            }
        }
    }

    public void SendEnemyDamage(){
        DemoCoder encoder = new DemoCoder(1024);
        foreach(EnemyHealth enemy in GameObject.FindObjectsOfType<EnemyHealth>()){
            if(enemy.transientHealthLoss > 0){
                int id = enemy.GetComponent<NetworkIdentity>().getObjectId();
                encoder.addEnemyDamage(id, enemy.transientHealthLoss);
                enemy.transientHealthLoss = 0;
            }
        }
        byte error;
        NetworkTransport.Send(socketId, hostId, myReliableChannelId, encoder.getArray(), 1024, out error);
    }

    
    public void SendARUpdate(){
        //method for sending AR information to VR
        DemoCoder encoder = new DemoCoder(1024);
        encoder.addARUpdate((byte)MessageIdentity.Type.ARUpdateVR, (byte)Beam.type, NetworkInterface.GetCameraTransform());
        byte error;
        NetworkTransport.Send(socketId, hostId, myStateChannelId, encoder.getArray(), 1024, out error);
    }

    public void SendVRBroadcast(){
        DemoCoder encoder = new DemoCoder(1024);
        if(tracker){
            encoder.addSerial((Byte)MessageIdentity.Type.VRUpdateAR, -1, -1, tracker.transform);
            // TODO need to send other client pos and beams to AR clients
        }
        encoder.addVREyeUpdate(VREye.GetComponent<PlayerHealth>().currentHealth, VREye.transform);

        foreach(KeyValuePair<int, GameObject> kvp in ARPlayers){
            Debug.Log("Sending Tracker info to client " + kvp.Key);
            byte error;
            NetworkTransport.Send(socketId, kvp.Key, myStateChannelId, encoder.getArray(), 1024, out error);
        }
        
        
    }

    /*
    private void SendPing(int connectionId){
        byte error;
        byte[] data = {0};
        NetworkTransport.Send(socketId, connectionId, myPingChannelId, data, 1, out error);
        pingSent = true;
    }
    */

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
        clientsConnected++;
        GameObject player = Instantiate(playerModel, new Vector3(0,0,0), new Quaternion(0,0,0,0));
        ARPlayers.Add(connectionId, player);
        byte error2;
        DemoCoder encoder = new DemoCoder(1024);
        NetworkIdentity[] networkIdentities = getNetworkIdentities();
        foreach(NetworkIdentity identity in networkIdentities){
            Debug.Log("Sending spawn state of enemies");
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

    public bool HandleClientDisconnect(int connectionId){
        GameObject player;
        clientsConnected--;
        ARPlayers.TryGetValue(connectionId, out player);
        GameObject.Destroy(player);
        ARPlayers.Remove(connectionId);
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
        Debug.Log("Has damaged enemy " + id);
        EnemyHealth eh = gameObject.GetComponent<EnemyHealth>();
        if (eh != null) {
            //just use damage, that's fine
            eh.Damage(damage);
        } else {
            Debug.LogError("Couldn't find enemy health tracking from network id" + id);
        }
    }

    private void HandleGeneralUpdate(int index, DemoCoder decoder){
        if(index == 0){
            Henge henge = GameObject.FindObjectOfType<Henge>();
            henge.SetRuneState(decoder.GetPortalRunes(index, henge.getSize()));
            henge.transform.position = decoder.GetPosition(index);
            henge.transform.rotation = decoder.GetRotation(index);
        }else{
            GameObject instance;
            int id = decoder.GetID(index);
            networkedObjects.TryGetValue (id, out instance);
            EnemyHealth eh = instance.GetComponent<EnemyHealth>();
            if (eh != null) {
                //keeps track of networked and local at the same time
                int currentHealth = eh.GetHealth();
                int networkedHealth = decoder.GetEnemyHealth(index) - eh.transientHealthLoss;
                //don't reset transient, since this may still need to be transmitted
                eh.SetHealth(Math.Min(currentHealth, networkedHealth));
            } else {
                Debug.LogError("Couldn't find enemy health tracking from network id" + id);
            }
            instance.transform.position = decoder.GetPosition(index);
            instance.transform.rotation = decoder.GetRotation(index);
        }

    }


    private void HandleARUpdateVR(int clientId, Vector3 pos, Quaternion rot, int shootEnum){
        GameObject gameObject;
        ARPlayers.TryGetValue(clientId, out gameObject);
        gameObject.transform.position = pos;
        gameObject.transform.rotation = rot;
        switch (shootEnum) {
        case (int)Beam.beamType.Damage:
            gameObject.GetComponent<ARClient>().Damage();
            break;
        case (int)Beam.beamType.Heal:
            gameObject.GetComponent<ARClient>().Heal();
            break;
        default:
            gameObject.GetComponent<ARClient>().Beamless();
            break;
        }
    }

    private void HandleVRUpdateAR(Vector3 pos, Quaternion rot){
        //NetworkInterface.UpdateTrackerPose(pos, rot);
    }

    private void HandleHealPlayer(int heal) {
        VREye.GetComponent<PlayerHealth>().Heal(heal);
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
            DamageEnemy = 5,
            ARUpdateVR = 6,
            VRUpdateAR = 7,
            HealPlayer = 8,
            GeneralUpdate = 9,
            VREyeUpdate = 10,
            Ping = 11
        }
    }


    public enum beamType : byte {
		None = 0,
		Damage = 1,
		Heal = 2
	}

    #endregion

}