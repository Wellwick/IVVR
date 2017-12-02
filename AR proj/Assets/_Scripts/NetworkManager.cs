using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkManager : MonoBehaviour {

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

	private UnityARCameraManager ARManager;


	#region Unity_Functions

	// Use this for initialization
	void Start () {
		//needs to host!
		networkInitialised = false;

		if (!networkInitialised)
		{
			NetworkTransport.Init();
			Debug.Log("Host Started");

			ConnectionConfig config = new ConnectionConfig();
			myUnreliableChannelId = config.AddChannel(QosType.Unreliable);
			myUpdateChannelId = config.AddChannel(QosType.Reliable);
			myStateChannelId = config.AddChannel(QosType.StateUpdate);
			HostTopology topology = new HostTopology(config, 1);
			socketId = NetworkTransport.AddHost(topology);
			Debug.Log(socketId);
			/* TODO For the time being! */
		}
		// VR device is no longer the one trying to connect
		/* BRING THIS BACK FOR PHONE */
		//connectionId = NetworkTransport.Connect(socketId, "137.205.112.42", 9090, 0, out error);

		ARManager = GameObject.FindObjectOfType<UnityARCameraManager>();
	}

	// Update is called once per frame
	void Update () {
		//test for buttons to do stuff! 

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
				break;
			case NetworkEventType.ConnectEvent: //AR connects
				Debug.Log("Connection request from id: " + connectionId + " Received");
				this.connectionId = connectionId;
				break;
			case NetworkEventType.DataEvent:
				NetworkMessage data;
				GameObject instance;
				Debug.Log("Data Received");
				BinaryFormatter bf = new BinaryFormatter();
				using(MemoryStream ms = new MemoryStream(recBuffer)){
					data = bf.Deserialize(ms) as NetworkMessage;
				}
				switch (data.type){
					case 0: //start
					case 1: //adding request from VR
						instance = spawnManager.SpawnObject(data.prefabId.Value, data.transform);
						NetworkIdentities.networkedObjects.Add(data.id.Value, instance);
						break;
					case 3: //receiving updates
						Debug.Log("Trying to update");
						NetworkIdentities.networkedObjects.TryGetValue(data.id.Value, out instance);
						SerializeableTransform st = data.transform;
						instance.transform.position = new Vector3(st.posX, st.posY, st.posZ);
						instance.transform.rotation = new Quaternion(st.rotX, st.rotY, st.rotZ, st.rotW);
						break;
					case 6:
						//this means we have tracker info!
						// THIS IS ONLY A TEST!
						Debug.Log("Recieved tracker position");
						SerializeableTransform st2 = data.transform;
						Camera.main.transform.position = new Vector3(st2.posX, st2.posY, st2.posZ);
						break;						
					default:
						Debug.Log("invalid message type");
						break;

				}
				break;
			case NetworkEventType.DisconnectEvent: //AR disconnects
				networkInitialised = false;
				Debug.Log("Disconnect Received");
				break;
			}
		}

	}

	#endregion

	#region Networking

	public void Connect(){
		byte error;
		networkInitialised = true;
		connectionId = NetworkTransport.Connect (socketId, "137.205.112.42", 9090, 0, out error);
		Debug.Log (((NetworkError)error).ToString());

	}

	public void RequestSpawn(int prefabId){
		Debug.Log ("Requesting spawn of prefab: " + ((Prefabs.PID)prefabId).ToString());
		NetworkMessage message = new NetworkMessage(2, null, prefabId, null);
		byte error;
		BinaryFormatter bf = new BinaryFormatter();
		using(MemoryStream ms = new MemoryStream()){
			bf.Serialize(ms, message);
			Debug.Log(ms.ToArray().Length);
			NetworkTransport.Send(socketId, connectionId, myUnreliableChannelId, ms.ToArray(), 1024, out error);
		}
	}



	#endregion

	#region Classes

	[System.Serializable]
    public class NetworkMessage{
        
		public byte type;
        public int? id;
        public int? prefabId;

        public SerializeableTransform transform;

		public NetworkMessage(byte type, int? id, int? prefabId, SerializeableTransform transform){
			this.type = type;
			this.id = id;
			this.prefabId = prefabId;
			this.transform = transform; 

		}

		public override string ToString(){
			return "Message type: " + type + "\n Object Id: " + id + "\nPrefab Id: " + prefabId +  "\n" + transform.ToString();
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
        }

        public override string ToString(){
            return "x = " + posX + "\ny = " + posY + "\nz = " + posZ;
        }

    }

	#endregion
}
