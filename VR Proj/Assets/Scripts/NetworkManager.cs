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
    public string connection_ip = "127.0.0.1";
    public int connection_port = 7777;

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
	private bool networkInitialised;
    private int clientsConnected = 0;
    private int[] clientIds;

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
        clientIds = new int[MAX_CONNECTIONS];
        //needs to host!
        networkInitialised = false;


        if (!networkInitialised){
            NetworkTransport.Init();
            Debug.Log("Host Started");
            ConnectionConfig config = new ConnectionConfig();
            config.SendDelay = 0;
            myReliableChannelId = config.AddChannel(QosType.Reliable);
            myUpdateChannelId = config.AddChannel(QosType.StateUpdate);
            myStateChannelId = config.AddChannel(QosType.StateUpdate);
            HostTopology topology = new HostTopology(config, MAX_CONNECTIONS);
            socketId = NetworkTransport.AddHost(topology, 9090);
            Debug.Log("Socket ID: " + socketId);
            networkInitialised = true;/* TODO For the time being! */
        }

        //initialise timer
	}

    #endregion 

	
    #region Update
	void Update () {
		//test
        //Debug.Log("Coordinates for Left Controller: " + leftController.transform.position.ToString());
        /* GET RID OF THIS FOR PHONE */
        /* PROBABLY WANT TO MOVE THIS ELSEWHERE, LIKE A USER CREATED SPAWN MANAGER */
        if (Input.GetKeyDown(KeyCode.A))
            Camera.GetComponent<shootBall>().throwBall(1);
        else if (Input.GetKeyDown(KeyCode.S))
            Camera.GetComponent<wallDemo>().spawnWall();
        else if (Input.GetKeyDown(KeyCode.D))
            Camera.GetComponent<wallDemo>().demolishWall();
        else if (Input.GetKeyDown(KeyCode.F))
            spooker.GetComponent<Spook>().spookPlayer();

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
                    SendUpdate(connectionId);
                    //finished update, save timer val
                    break;
                case NetworkEventType.ConnectEvent: //AR connects
                    Debug.Log("Connection request from id: " + connectionId + " Received");
                    HandleConnect(connectionId);
                    break;
                case NetworkEventType.DataEvent:
                    Debug.Log("Data Received");
                    Coder decoder = new Coder(recBuffer);
                    for(int i = 0; i < decoder.getCount(); i++){
                        switch (decoder.GetType(i)){
                            case 0:
                                HandleSpawn(decoder.GetAssetID(i),decoder.GetPosition(i), decoder.GetRotation(i), decoder.GetVelocity(i));
                                break;
                            case 1:
                                HandleUpdate(decoder.GetID(i), decoder.GetPosition(i), decoder.GetRotation(i));
                                break;
                            case 2:
                                HandleSpawn(decoder.GetAssetID(i), decoder.GetPosition(i), decoder.GetRotation(i), decoder.GetVelocity(i));
                                break;
                            case 3:
                                HandleRemove(decoder.GetID(i));
                                break;
                            case 4:
                                //fix later
                                break;
                            case 5:
                                spooker.GetComponent<Spook>().spookPlayer();
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
                    Coder trackerEncode = new Coder(1024);
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
        Coder encoder = new Coder(50);
        encoder.addSerial((Byte)MessageIdentity.Type.Request, -1, assetId, transform);
        NetworkTransport.Send(socketId, hostId, myReliableChannelId, encoder.getArray(), 1024, out error);
        return true;
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
            Coder encoder = new Coder(1024);
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
                encoder = new Coder(1024);
            }
        }

        return true;
    }

    public void SendSpawn(GameObject gameObject) {
        byte error2;
        Coder encoder = new Coder(50);
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
        Coder encoder = new Coder(50);
        encoder.addSerial((byte)MessageIdentity.Type.Remove, objectId, -2, null);
        foreach(int id in clientIds){
            NetworkTransport.Send(socketId, id, myReliableChannelId, encoder.getArray(), 50, out error2);
        }
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
        Coder encoder = new Coder(1024);
        NetworkIdentity[] networkIdentities = getNetworkIdentities();
        foreach(NetworkIdentity identity in networkIdentities){ 
            encoder.addSerial((Byte)MessageIdentity.Type.Initialise, identity.getObjectId(), (int)Prefabs.PID.Ball, identity.gameObject.transform);
            if(encoder.isFull()){
                NetworkTransport.Send(socketId, connectionId, myReliableChannelId, encoder.getArray(), 1024, out error2);
                encoder = new Coder(1024);
            }
        }
        NetworkTransport.Send(socketId, connectionId, myReliableChannelId, encoder.getArray(), 1024, out error2);
        return true;
    }

    private void HandleSpawn(int assetId, Vector3 pos, Quaternion rot, Vector3 vel){
        GameObject instance = Instantiate(spawnables[assetId], pos, rot);

    }

    private void HandleRemove(int id){
        GameObject instance;
        networkedObjects.TryGetValue(id, out instance);
        Destroy(instance);
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
            ARUpdate = 7
        }
    }

    #endregion

}
