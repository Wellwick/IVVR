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

	public static bool serverHosted = false;

	private int socketId;
	private int hostId;
	private int myReliableChannelId;
	private int myUnreliableChannelId;
	private int myUpdateChannelId;
    private int myStateChannelId;
	private bool networkInitialised;
    private bool clientConnected;
    private int clientsConnected = 0;
    private int[] clientIds;

    public int MAX_CONNECTIONS;
	public GameObject leftController;
	public GameObject rightController;
    public GameObject Camera;
    public GameObject spooker;
    public GameObject throwBall;
    public GameObject wallDemo;
    public GameObject tracker;
    //dictionary to identify individual objects, may not be super necessary eventually
    public Dictionary<int, GameObject> networkedObjects;
    //message queue to help ease load off of the send buffer.
    //public Queue messageQueue = new Queue();
    public Dictionary<int, GameObject> watchList = new Dictionary<int, GameObject>();


    //value to check when we should send a new batch of updates
    private float timer;
    public int updateRatePerSec = 20;
	// Use this for initialization
	void Start () {
        clientIds = new int[MAX_CONNECTIONS];
        //needs to host!
        networkInitialised = false;


        if (!networkInitialised)
        {
            NetworkTransport.Init();
            Debug.Log("Host Started");
            ConnectionConfig config = new ConnectionConfig();
            config.SendDelay = 0;
            myReliableChannelId = config.AddChannel(QosType.Reliable);
            myUpdateChannelId = config.AddChannel(QosType.StateUpdate);
            myStateChannelId = config.AddChannel(QosType.StateUpdate);
            HostTopology topology = new HostTopology(config, 2);
            socketId = NetworkTransport.AddHost(topology, 9090);
            Debug.Log("Socket ID: " + socketId);
            networkInitialised = true;/* TODO For the time being! */
        }
        //get the list of networked objects saved in a list
        GameObject[] netObjects = GameObject.FindGameObjectsWithTag("NetworkedObject");
        //put them in a list
        networkedObjects = new Dictionary<int, GameObject>();
        for (int i = 0; i < netObjects.Length; i++) {
            //assume they are all balls to start!
            GameObject gameObject = netObjects[i];
            int id = gameObject.GetComponent<NetworkIdentity>().getObjectId();
            networkedObjects.Add(id, gameObject);

        }
        //initialise timer
        timer = Time.timeSinceLevelLoad;
	}

	// Update is called once per frame
	void Update () {
		//test
        //Debug.Log("Coordinates for Left Controller: " + leftController.transform.position.ToString());
        /* GET RID OF THIS FOR PHONE */
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
                    if (clientConnected/* && Input.GetKeyDown(KeyCode.U)*/) {
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
                            encoder.addSerial(3, kvp.Key, -1, kvp.Value.transform);
                        }
         
                        if(!empty){
                            byte error3;
                            NetworkTransport.Send(socketId, connectionId, myUpdateChannelId, encoder.getArray(), 1024, out error3);
                            encoder = new Coder(1024);
                        }

                        //finished update, save timer val
                        timer = Time.timeSinceLevelLoad;
                    }
                    break;
                case NetworkEventType.ConnectEvent: //AR connects
                    Debug.Log("Connection request from id: " + connectionId + " Received");
                    clientIds[clientsConnected] = connectionId;
                    clientsConnected++;
                    byte error2;
                    Coder initEncoder = new Coder(1024);
                    for (int i = 0; i<networkedObjects.Count; i++) {
                        initEncoder.addSerial(0, i, (int)Prefabs.PID.Ball, networkedObjects[i].transform);
                        if(initEncoder.isFull()){
                            NetworkTransport.Send(socketId, connectionId, myReliableChannelId, initEncoder.getArray(), 1024, out error2);
                            initEncoder = new Coder(1024);
                            break;
                        }
                    }
                    clientConnected = true;
                    break;
                case NetworkEventType.DataEvent:
                    Debug.Log("Data Received");
                    Coder decoder = new Coder(recBuffer);
                    for(int i = 0; i < decoder.getCount(); i++){
                        switch (decoder.GetType(i)){
                            case 0:
                                //leftController.GetComponent<ControllerGrabObject>().RemoveFire();
                                //rightController.GetComponent<ControllerGrabObject>().RemoveFire();
                                break;
                            case 1:
                                //leftController.GetComponent<ControllerGrabObject>().SpawnFire();
                                //rightController.GetComponent<ControllerGrabObject>().SpawnFire();
                                break;
                            case 2:
                                Debug.Log("Trying to throw ball");
                                throwBall.GetComponent<shootBall>().throwBall(decoder.GetPrefabID(i)); //shootBall.cs is on camera(eyes) shoots ball in direction facing.
                                break;
                            case 3:
                                wallDemo.GetComponent<wallDemo>().spawnWall();
                                break;
                            case 4:
                                wallDemo.GetComponent<wallDemo>().demolishWall();
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
            if (clientConnected) {
                //also send the transform of the tracker over the state channel

                Debug.Log("Sending tracker info");
                Coder trackerEncode = new Coder(1024);
                trackerEncode.addSerial(6, -1, -1, tracker.transform);
                byte error2;
                foreach(int id in clientIds){
                    NetworkTransport.Send(socketId, id, myStateChannelId, trackerEncode.getArray(), 1024, out error2);
                }
            }
            if(Input.GetKeyDown(KeyCode.P)){
                Debug.Log(watchList.ToString());
            }
        }
	}

    //Add object to the list
    public void addObject(GameObject gameObject, Prefabs.PID objectType) {
        byte error2;
        Coder encoder = new Coder(50);
        int objectId = gameObject.GetComponent<NetworkIdentity>().getObjectId();
        networkedObjects.Add(objectId, gameObject);
        encoder.addSerial((byte)MessageIdentity.Type.Spawn, objectId, (int)objectType, gameObject.transform);
        foreach(int id in clientIds){
            NetworkTransport.Send(socketId, id, myReliableChannelId, encoder.getArray(), 50, out error2);
        }
    }

    public class Coder{

        private byte[] buff;
        private byte count;
        private int size;
        public Coder(int size){
            buff = new byte[size];
            count = 0;
            this.size = size;
        }

        public Coder(byte[] array) {
            buff = array;
            count = buff[0];
            size = array.Length;
        }

        public byte[] getArray() {
            buff[0] = count;
            return buff;
        }

        public byte getCount(){
            return count;
        }

        public bool isFull() {
            return ((((count+1)*49)+1)>size);
        }

        public void addSerial(byte type, int id, int prefabId, Transform transform){
            if (isFull()) {
                Debug.LogError("Coder array is already full, can't add type " + type + " object id " + id);
                return;
            }
            int index = 1 + (count++*49);
            buff[index] = type;
            writeIn(id, index+1);
            writeIn(prefabId, index+5);
            if(transform == null){
                return;
            }
            //setup for position
            Vector3 pos = transform.position;
            writeIn(pos.x, index+9);
            writeIn(pos.y, index+13);
            writeIn(pos.z, index+17);

            //setup for rotation
            Quaternion rot = transform.rotation;
            writeIn(rot.x, index+21);
            writeIn(rot.y, index+25);
            writeIn(rot.z, index+29);
            writeIn(rot.w, index+33);

            //setup for velocity
            Rigidbody rb = transform.GetComponent<Rigidbody>();
            if (rb == null) {
                return;
            }
            Vector3 vel = rb.velocity;
            writeIn(vel.x, index+37);
            writeIn(vel.y, index+41);
            writeIn(vel.z, index+45);

        }

        private void writeIn(int value, int pos) {
            byte[] writeIn = BitConverter.GetBytes(value);
            for (int i = 0; i < writeIn.Length; i++) {
                buff[i+pos] = writeIn[i];
            }
        }

        private void writeIn(float value, int pos) {
            byte[] writeIn = BitConverter.GetBytes(value);
            for (int i = 0; i < writeIn.Length; i++) {
                buff[i+pos] = writeIn[i];
            }
        }

        public int readOutInt(int pos) {
            return BitConverter.ToInt32(buff, pos);
        }

        public float readOutFloat(int pos) {
            return BitConverter.ToSingle(buff,pos);
        }

        public byte GetType(int index) {
            if(illegalVal(index)){
                return 255;
            }
            //move the index to correct position
            index = 1 + (index*49);

            return buff[index];
        }

        public int GetID(int index) {
            if(illegalVal(index)){
                return -2;
            }
            //move the index to correct position
            index = 1 + (index*49);

            return readOutInt(index+1);
        }

        public int GetPrefabID(int index) {
            if(illegalVal(index)){
                return -2;
            }
            //move the index to correct position
            index = 1 + (index*49);

            return readOutInt(index+5);
        }

        public Vector3 GetPosition(int index) {
            if(illegalVal(index)){
                return new Vector3(0,0,0);
            }
            //move the index to correct position
            index = 1 + (index*49);

            //we already have the array
            //sort out in a sec
            float posX = readOutFloat(index+9);
            float posY = readOutFloat(index+13);
            float posZ = readOutFloat(index+17);
            return new Vector3(posX, posY, posZ);
        }

        public Quaternion GetRotation(int index) {
            index = 1 + (index*49);
            float rotX = readOutFloat(index+21);
            float rotY = readOutFloat(index+25);
            float rotZ = readOutFloat(index+29);
            float rotW = readOutFloat(index+33);
            return new Quaternion(rotX, rotY, rotZ, rotW);

        }

        public Vector3 GetVelocity(int index) {
            if(illegalVal(index)){
                return new Vector3(0,0,0);
            }
            //move the index to correct position
            index = 1 + (index*49);

            //once again, already have the array
            float velX = readOutFloat(index+37);
            float velY = readOutFloat(index+41);
            float velZ = readOutFloat(index+45);

            return new Vector3(velX, velY, velZ);
        }

        private bool illegalVal(int index) {
            if (index > buff[0]) {
                Debug.LogError("Coded message count does not reach value " + index);
                return true;
            }
            return false;
        }

    }

    [System.Serializable]
    public class NetworkMessage{

		public byte type;
        public int? id;
        public int? prefabId;

        public SerializeableTransform transform;

		public NetworkMessage(byte type, int? id, int? prefabId, Transform transform){
			this.type = type;
			this.id = id;
			this.prefabId = prefabId;
			this.transform = new SerializeableTransform(transform);

		}

    }

    [System.Serializable]
    public class SerializeableTransform{
        public float posX;
        public float posY;
        public float posZ;
        public float rotX;
        public float rotY;
        public float rotZ;
        public float rotW;


        public SerializeableTransform(Transform transform){
            posX = transform.position.x;
            posY = transform.position.y;
            posZ = transform.position.z;
            rotX = transform.rotation.x;
            rotY = transform.rotation.y;
            rotZ = transform.rotation.z;
            rotW = transform.rotation.w;
        }

        public override string ToString(){
            return "x = " + posX + "\ny = " + posY + "\nz = " + posZ;
        }

    }
}
