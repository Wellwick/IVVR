using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Networking;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

/*
 * Network Manager framework for VR and AR. Uses Server-Client network framework where the VR host acts as the server and has
 * Authority over all objects in the scene.
 * Should be extended for both AR and VR scenes separeately
 */

public class NetworkManager : MonoBehaviour {

    /* 
     * Variables that are visible through the inspector for developer use 
     */
    #region Inspector_vars
    [Header("Server Setttings")]
    public int MAX_CONNECTIONS = 1;                     //max number of connections
    public string connection_ip = "137.205.112.42";     //the connection ip 
    public int connection_port = 9090;                  //connection port
    public int tickrate = 60;                           //tickrate, must be set at the beginning and cannot be changed

    [Header("Spawning")]
    public GameObject[] spawnables = new GameObject[0]; //array of spawnabe assets, for any object that wants to be spawned it must be identical in the VR and AR scenes

    /*
     * Channels for sending data
     */
    [Header("Channels")]
	private int myReliableChannelId;
	private int myUpdateChannelId;

    /*
     * VR relevant objects, controllers can be ignored in AR scene
     * VREye must be set to a gameobject the track VR position in AR and VR. It should be set to the main camera in the VR scene
     * playerModel must be set to track AR positions in AR and in VR. Must just be the model and not have any attached scripts
     */
    [Header("VR")]
	public GameObject leftController;
	public GameObject rightController;
    public GameObject VREye = null;
    public GameObject playerModel = null;


    [Header("Other Settings")]
    public bool isHost = true;              //true if VR host,false otherwise
    public bool debugARPosition = false;    //debug for printing all AR players positions
    public bool debugVRPosition = false;    //debug for printing VR player position in AR
     

    #endregion

    #region Global_vars
    private int selfId;                         // Own socket Id
	private bool networkInitialised = false;    // True if the network setup has completed
    private int clientsConnected = 0;           // Tracks the number of clients connected
    
    


    #endregion

    /*
     * Structures used throughout the network manager:
     *      - watch list is the dictionary used to ensure only objects that are moving are being updated
     *      - spawnAssets is the dictionary that maps a Asset id string to an integer, the integer is then sent to the AR players when a spawn of that asset is made
     *      - networkedObjects is a dictionary that keeps track of every networked object regardless of if it is moving
     *      - ARPlayers is the dictionary which links a model of an AR player to the connectId of that player, used to track AR players
     */
    #region Global_structures
    
    public Dictionary<int, GameObject> watchList = new Dictionary<int, GameObject>();
    public Dictionary<String, int> spawnAssets = new Dictionary<String, int>();
    public Dictionary<int, GameObject> networkedObjects = new Dictionary<int, GameObject>();
    public Dictionary<int, GameObject> ARPlayers = new Dictionary<int, GameObject>();


    #endregion

    #region Unity Functions
    //on awake, find all the components that should be tracked by checking the spawnables array
    void Awake(){
        for(int i = 0; i < spawnables.Length; i++){
            String assetId = NetworkTransport.GetAssetId(spawnables[i]);
            spawnAssets.Add(assetId, i);
        }
    }

    #region Start

	void Start () {
        if (!networkInitialised){
            NetworkTransport.Init();                                            //intialises network
            Debug.Log("Host Started");
            ConnectionConfig config = new ConnectionConfig();                   //create a basic configuration
            /*************************************************************/
            //configuration settings
            config.SendDelay = 0;                                               
            myReliableChannelId = config.AddChannel(QosType.Reliable);
            myUpdateChannelId = config.AddChannel(QosType.StateUpdate);
            myStateChannelId = config.AddChannel(QosType.StateUpdate);
            /*************************************************************/
            HostTopology topology = new HostTopology(config, MAX_CONNECTIONS);  //sets the topology with the max connections and the configuraation crafted
            selfId = NetworkTransport.AddHost(topology, connection_port);       // add self to the topology and store Id
            Debug.Log("Socket ID: " + selfId);
            networkInitialised = true;
        }
        InvokeRepeating("SendUpdate", 0.1f, 1/tickrate);                        //invoke update method which runs every 1/tickrate times per second
	}

    #endregion


    #region Update
	void Update () {

        if (networkInitialised)
        {
            int recHostId;                          // Own id
            int connectionId;                       // sender Id
            int channelId;                          // channel Id
            int bufferSize = 1024;                  // buffer size
            byte[] recBuffer = new byte[bufferSize]; //Receiving buffer
            int dataSize;                           //data size
            byte error;                             // error byte
            NetworkEventType recData = NetworkTransport.Receive(out recHostId, out connectionId, out channelId, recBuffer, bufferSize, out dataSize, out error);
            switch (recData)
            {
                case NetworkEventType.Nothing:
                    break;
                case NetworkEventType.ConnectEvent: //AR connects
                    Debug.Log("Connection request from id: " + connectionId + " Received");

                    //if a connection is received and this is the host, then handle the connection 
                    if(isHost){
                        HandleConnect(connectionId);
                    }
                    break;
                
                //if data is received
                case NetworkEventType.DataEvent:
                    Debug.Log("Data Received");

                    //create coder for the purpose of decoding
                    Coder decoder = new Coder(recBuffer);
                    for(int i = 0; i < decoder.getCount(); i++){

                        //get message type and call the correspnding handler for the given message type
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
                            case (byte)MessageIdentity.Type.ARPosition:
                                HandleARPosition(connectionId, decoder.GetPosition(i), decoder.GetRotation(i), decoder.GetShootEnum(i));
                                break;
                            case (byte)MessageIdentity.Type.VRPosition:
                                HandleVRPosition(decoder.GetPosition(i), decoder.GetRotation(i));
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

    #region Request Functions
    
    // Function for sending a spawn request to the server from a client
    public bool RequestSpawn(int assetId, Transform transform, int hostId, byte[] data){
        if(!ishost){
            byte error;
            Coder coder = new Coder(50);
            encoder.addSerial((Byte)MessageIdentity.Type.Request, -1, assetId, transform);  // Use coder to serialize a message to send to AR
            Send(hostId, myReliableChannelId, encoder.getArray(), 1024, out error);         // Send message to VR server
            return true;
        }
        
    }

    // Function for requesting a connection with the host/server
    public void RequestConnect(){
        if(!isHost){
            byte error;
            Debug.Log("Attempting to connect to <" + connection_ip + "> on port <" + connection_port + ">");
            int hostId = NetworkTransport.Connect(selfId, connection_ip, connection_port, 0, out error);        //connect using IP and port along wth own Id
        }
    }

    #endregion

    #region Send Functions

    // Basic function for sending a message, used to abstract the usage of NetworkTransport from developers
    public bool Send(int receiverId, int channelId, byte[] data){
        byte error;
        NetworkTransport.Send(selfId, receiverId, channelId, data, data.Length, out error);
        return error   
    }

    // Function for sending an update, this is called in InvokeRepeating in the function start()
    // It is called tickrate number of times a second
    public bool SendUpdate(int connectionId){
        foreach(KeyValuePair<int, GameObject> player in ARPlayers){  //for each connected client
            empty = true;
            Debug.Log("Trying to update client " + player.Key + " on " + watchList.Count + " objects"); 

            Coder coder = new Coder(1024);    //create new coder

            //if the VREye is not null then send the position in a packet 
            if(VREye){              
                empty = false;
                encoder.addSerial((Byte)MessageIdentity.Type.VRPosition, -1, -1, VREye.transform);
            }

            // For each player, add every other AR players position to the packet
            foreach(KeyValuePair<int, GameObject> players in ARPlayers){
                empty = false;
                if(players.Key != player.Key){
                    encoder.addSerial(ARPosition, -1, -1, kvp2.Value.transform);
                }
            }

            // For each object in the watchlist, add it's position to the packet
            foreach(KeyValuePair<int, GameObject> kvp in watchList){
                empty = false;
                if (encoder.isFull()){
                    break;
                }
                encoder.addSerial((Byte)MessageIdentity.Type.Update, kvp.Key, -1, kvp.Value.transform);
            }

            //If the packet is not empty then send the packet to the current player being checked
            if(!empty){
                byte error;
                Send(player.Key, myUpdateChannelId, encoder.getArray());
            }
        }

        return true;
    }

    // Send spawn command to AR players
    public void SendSpawn(GameObject gameObject) {
        byte error2;
        Coder encoder = new Coder(50);
        int objectId = gameObject.GetComponent<NetworkIdentity>().getObjectId();                            // Get the object Id of the object to send
        String assetId = NetworkTransport.GetAssetId(gameObject);                                           // Get the asset Id of the object to send
        int assetIdNum;
        spawnAssets.TryGetValue(assetId, out assetIdNum);                                                   // Convert the asset Id into asset number Id
        encoder.addSerial((byte)MessageIdentity.Type.Spawn, objectId, assetIdNum, gameObject.transform);    // Encode the informtaion into a "spawn" message
        foreach(KeyValuePair<int, GameObject> player in ARPlayers){
            Send(player.Key, myReliableChannelId, encoder.getArray());                                      // Send serialized information down the reliable channel
        }
    }

    // Send removal message to all clients, this message is automatically sent when a NetworkIdentity script is destroyed
    public void SendRemove(int objectId){
        byte error2;
        Coder encoder = new Coder(50);
        encoder.addSerial((byte)MessageIdentity.Type.Remove, objectId, -2, null);
        foreach(KeyValuePair<int, GameObject> player in ARPlayers){
            Send(player.Key, myReliableChannelId, encoder.getArray(), 50, out error2);
        }
    }

    #endregion

    #region Handler Functions

    // Function for handling an update message
    public bool HandleUpdate(int id, Vector3 pos, Quaternion rot){
        GameObject instance;
        networkedObjects.TryGetValue (id, out instance);    // Look for an existing instance in the networked objects dictionary
        instance.transform.position = pos;                  // Update the position of the instance
        instance.transform.rotation = rot;
        return true;
    }

    // Function for handling a new client connecting to the server
    public bool HandleConnect(int connectionId){
        clientsConnected++;

        //if the player model is set, then create a new object for the player
        if(playerModel){           
            GameObject player = Instantiate(playerModel, new Vector3(0,0,0), new Quaternion(0,0,0,0));
        }
        ARPlayers.Add(connectionId, player);                //add new player to dictionary, with connection Id as the key and gameobject as the value
        byte error;

        /************************************************************************************/
        // code for sending the state of the scene when a new client connects
        Coder encoder = new Coder(1024);
        NetworkIdentity[] networkIdentities = getNetworkIdentities();
        foreach(NetworkIdentity identity in networkIdentities){
            Debug.Log("Sending spawn state of enemies");
            int assetid;
            spawnAssets.TryGetValue(NetworkTransport.GetAssetId(identity.gameObject), out assetid);
            encoder.addSerial((Byte)MessageIdentity.Type.Initialise, identity.getObjectId(), assetid, identity.gameObject.transform);

            // If the encoder is full then send a message and then refresh the encoder
            if(encoder.isFull()){
                Send(connectionId, myReliableChannelId, encoder.getArray());
                encoder = new Coder(1024);
            }
        }
        /************************************************************************************/
        Send(connectionId, myReliableChannelId, encoder.getArray()); // Send initialsation packet
        return true;
    }

    // Function to ensure clients assets are properly cleaned when a client disconnects
    public bool HandleClientDisconnect(int connectionId){
        GameObject player;
        clientsConnected--;
        ARPlayers.TryGetValue(connectionId, out player);    // check if the player has a model
        if(player){                                         // If the player does have a model, destroy it
            GameObject.Destroy(player);
        }
        ARPlayers.Remove(connectionId);                     // remove player from the dictionary
        return true;
    }

    // Spawn an object in the client scene when a spawn request is received, after the object is spawned, set 
    // the Id of the object to the correct value sent by the server
    private void HandleClientSpawn(int assetId, int objectId, Vector3 pos, Quaternion rot, Vector3 vel){
        GameObject instance = Instantiate(spawnables[assetId], pos, rot);
        if(!isHost){
            instance.GetComponent<NetworkIdentity>().setObjectId(objectId);
        }

    }

    //Spawn an object that has been requested by the client
    private void HandleSpawnRequest(int assetId, Vector3 pos, Quaternion rot, Vector3 vel){
        GameObject instance = Instantiate(spawnables[assetId], pos, rot);
    }

    // Function to remove an object on a client when the server has removed the object 
    private void HandleRemove(int id){
        GameObject instance;
        if(networkedObjects.TryGetValue(id, out instance)){
            Destroy(instance);
        }else{
            Debug.Log("No tracked object mapped to the ID: " + id)
        }
        
    }

    /*
     * Function for updating/tracking the position of the VR player in the AR scene
     */
    private void HandleVRPosition(Vector3 pos, Quaternion rot){
        if(VREye){                                              // If the VREte object is not null
            VREye.transform.position = pos;                     // update the position and rotation of the model
            VREye.transform.rotation = rot;
        }else{                                                  // Else Debug
            Debug.Log("No Object assigned for VR player");
            if(debugVRPosition){
                Debug.Log("VR Player position: " + pos + "VR Player rotation: " + rot);
            }
        }

    }


    /*
     * Function for handling the case where a network manager receives an update to an Ar players position
     * Acts differently depending on if the script handling this is the host or not
     */
    private void HandleARPosition(int clientId, Vector3 pos, Quaternion rot){
        if(!isHost){                                                            //If not the host
            GameObject player;
            if(ARPlayers.TryGetValue(clientId, out player)){                    // Try and get a player model for a player to see if it exists 
                player.transform.position = pos;                                // If the model and id existed in the dictionary then update position
                player.transform.rotation = rot;
            }else{
                if(playerModel){                                                // If the playerModel is set in the editor and there is no record in the dictionary
                    GameObject player = Instantiate(playerModel, pos, rot);     // create a new model with the positiona and roation sent 
                    ARPlayers.add(clientId, player)                             // add new id and model to the ARPlayers array
                }else{
                    Debug.Log("Add a player model to track AR player position");
                    if(debugARPosition){
                        Debug.Log("Player " + clientId + " position: " + pos + "Player " + clientId + " Rotation: " + rot);
                    }
                }
            }
        }else{
            Debug.Log("Receiving message from AR");
            GameObject player;
            ARPlayers.TryGetValue(clientId, out player);                        // Check the dictionary for an existing player and model
            if(player){                                                         // If the model is not set to null
                player.transform.position = pos;                                // Set the player to the updated position 
                player.transform.rotation = rot;                                
            }else{
                Debug.Log("Add a player model to track AR player position")     //else debug
                if(debugARPosition){
                    Debug.Log("Player " + clientId + " position: " + pos + "Player " + clientId + " Rotation: " + rot);
                }
            }
            
        }
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



    /*
     * Class for defining message ID's
     * creates enums for different message types
     * when a message needs to be sent cast the unique message type to a byte to be sent
     * can add more types if necessary 
     */
    public class MessageIdentity : MonoBehaviour {

        public enum Type : byte{
            Initialise = 0,
            Update = 1,
            Spawn = 2,
            Remove = 3,
            Request = 4,
            ARPosition = 6,
            VRPosition = 7,
        }
    }


    #endregion

}