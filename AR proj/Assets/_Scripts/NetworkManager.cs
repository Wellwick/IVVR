using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour
{

	public static bool serverHosted = false;
	public SpawnManager spawnManager;
	public int updateTimer;

	private int socketId;
	private int connectionId;
	private int myUnreliableChannelId;
	private int myUpdateChannelId;
	private int myStateChannelId;
	private bool networkInitialised;
	private float timer = 0;

	//string hostIP = "137.205.112.43"; //DCS machine
	string hostIP = "172.20.10.4"; //Chris computer

	//private UnityARCameraManager ARManager;
	private TextManager textManager;
	//private UnityEngine.XR.iOS.UnityARSessionNativeInterface ARNativeInterface;


	#region Unity_Functions

	// Use this for initialization
	void Start ()
	{
		//needs to host!
		networkInitialised = false;

		if (!networkInitialised) {
			NetworkTransport.Init ();
			Debug.Log ("Host Started");

			ConnectionConfig config = new ConnectionConfig ();
			myUnreliableChannelId = config.AddChannel (QosType.Unreliable);
			myUpdateChannelId = config.AddChannel (QosType.Reliable);
			myStateChannelId = config.AddChannel (QosType.StateUpdate);
			HostTopology topology = new HostTopology (config, 1);
			socketId = NetworkTransport.AddHost (topology);
			Debug.Log (socketId);
			/* TODO For the time being! */
		}
		// VR device is no longer the one trying to connect
		/* BRING THIS BACK FOR PHONE */
		//connectionId = NetworkTransport.Connect(socketId, "137.205.112.42", 9090, 0, out error);

		//ARManager = GameObject.FindObjectOfType<UnityARCameraManager> ();
		textManager = GameObject.FindObjectOfType<TextManager> ();
		//ARNativeInterface = GameObject.FindObjectOfType<UnityEngine.XR.iOS.UnityARSessionNativeInterface> ();
	}

	// Update is called once per frame
	void Update ()
	{
		//test for buttons to do stuff! 

		if (networkInitialised) {
			int recHostId;
			int connectionId;
			int channelId;
			byte[] recBuffer = new byte[1024]; //Info for actions to occur
			int bufferSize = 1024;
			int dataSize;
			byte error;
			NetworkEventType recData = NetworkTransport.Receive (out recHostId, out connectionId, out channelId, recBuffer, bufferSize, out dataSize, out error);
			switch (recData) {
			case NetworkEventType.Nothing:
				break;
			case NetworkEventType.ConnectEvent: //AR connects
				Debug.Log ("Connection request from id: " + connectionId + " Received");

				textManager.changeNetworkString ("Connected to " + hostIP);
				this.connectionId = connectionId;
				break;
			case NetworkEventType.DataEvent:
				Coder decoder = new Coder(recBuffer);
				GameObject instance;
				Debug.Log ("Data Received");
				for (int i = 0; i < decoder.getCount(); i++) {
					switch (decoder.GetType(i)) { 
					case 0: //start
					case 1: //adding request from VR
						instance = spawnManager.SpawnObject (decoder.GetPrefabID(i), decoder.GetPosition(i), decoder.GetRotation(i), decoder.GetVelocity(i));
						NetworkIdentities.networkedObjects.Add (decoder.GetID(i), instance);
						break;
					case 3: //receiving updates
						Debug.Log ("Trying to update");
						NetworkIdentities.networkedObjects.TryGetValue (decoder.GetID(i), out instance);
						instance.transform.position = decoder.GetPosition(i);
						instance.transform.rotation = decoder.GetRotation(i);
						//TODO set velocity if there is a rigidbody
						break;
					case 6:
							//this means we have tracker info!
							// THIS IS ONLY A TEST!
						//Debug.Log ("Received tracker position");

						//ARManager.UpdatePosition (new Vector3 (st2.posX, st2.posY, st2.posZ));
						//TODO: remove the changes done in ARManager. PARTLY DONE.

						textManager.changeTrackerRotationString (decoder.GetRotation(i));

						Vector3 pos = decoder.GetPosition(i);
						Quaternion rot = decoder.GetRotation(i);

						UnityEngine.XR.iOS.UnityARSessionNativeInterface.updateTrackerPosition(pos.x, pos.y, pos.z);
						UnityEngine.XR.iOS.UnityARSessionNativeInterface.updateTrackerRotation(rot.x, rot.y, rot.z, rot.w);


						break;						
					default:
						Debug.Log ("invalid message type");
						break;

					}
				}
				break;
			case NetworkEventType.DisconnectEvent: //AR disconnects
				networkInitialised = false;
				textManager.changeNetworkString ("Disconnected from" + hostIP);
				Debug.Log ("Disconnect Received");
				break;
			}
		}

	}

	#endregion

	#region Networking

	//137.205.112.43
	public void Connect ()
	{
		InputField input = GameObject.FindObjectOfType<InputField>();
		Text inputText = input.GetComponentInChildren<Text>();
		if(inputText.text != ""){
			hostIP = inputText.text;
		}
		byte error;
		networkInitialised = true;
		connectionId = NetworkTransport.Connect(socketId, hostIP, 9090, 0, out error);

		textManager.changeNetworkString ("Connecting to " + hostIP);
		Debug.Log (((NetworkError)error).ToString ());

	}

	public void RequestSpawn (int prefabId)
	{
		Debug.Log ("Requesting spawn of prefab: " + ((Prefabs.PID)prefabId).ToString ());
		Coder encoder = new Coder(1024);
		encoder.addSerial(2, -1, prefabId, null);
		byte error;
		NetworkTransport.Send (socketId, connectionId, myUpdateChannelId, encoder.getArray(), 1024, out error);
	}



	#endregion

	#region Classes

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
            if(transform = null){
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
            Vector3 vel = transform.GetComponent<Rigidbody>().velocity;
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
	public class NetworkMessage
	{
        
		public byte type;
		public int? id;
		public int? prefabId;

		public SerializeableTransform transform;

		public NetworkMessage (byte type, int? id, int? prefabId, SerializeableTransform transform)
		{
			this.type = type;
			this.id = id;
			this.prefabId = prefabId;
			this.transform = transform; 

		}

		public override string ToString ()
		{
			return "Message type: " + type + "\n Object Id: " + id + "\nPrefab Id: " + prefabId + "\n" + transform.ToString ();
		}

	}

	[System.Serializable]
	public class SerializeableTransform
	{
		public float posX;
		public float posY;
		public float posZ;
		public float rotX;
		public float rotY;
		public float rotZ;
		public float rotW;


		public SerializeableTransform (Transform transform)
		{
			posX = transform.position.x;
			posY = transform.position.y;
			posZ = transform.position.z;
			rotX = transform.rotation.x;
			rotY = transform.rotation.y;
			rotZ = transform.rotation.z;
			rotW = transform.rotation.w;
		}

		public override string ToString ()
		{
			return "x = " + posX + "\ny = " + posY + "\nz = " + posZ;
		}

	}

	#endregion
}
