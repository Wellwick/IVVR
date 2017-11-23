using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkManager : MonoBehaviour {

	public static bool serverHosted = false;
	public SpawnManager spawnManager;
	private int socketId;
	private int connectionId;
	private int myUnreliableChannelId;
	private bool networkInitialised;

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
			HostTopology topology = new HostTopology(config, 1);
			socketId = NetworkTransport.AddHost(topology);
			Debug.Log(socketId);
			networkInitialised = true;/* TODO For the time being! */
		}
		// VR device is no longer the one trying to connect
		/* BRING THIS BACK FOR PHONE */
		//connectionId = NetworkTransport.Connect(socketId, "137.205.112.42", 9090, 0, out error);
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
				Debug.Log("Data Received");
				BinaryFormatter bf = new BinaryFormatter();
				using(MemoryStream ms = new MemoryStream(recBuffer)){
					data = bf.Deserialize(ms) as NetworkMessage;
				}
				switch (data.type){
					case 0:
						GameObject instance = spawnManager.SpawnObject(data.prefabId.Value, data.transform);
						NetworkIdentities.networkedObjects.Add(data.id.Value, instance);
						break;
					default:
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

	public void Connect(){
		byte error;
		connectionId = NetworkTransport.Connect (socketId, "137.205.112.42", 9090, 0, out error);
		Debug.Log (((NetworkError)error).ToString());

	}

	public void ProjectBall(){
		Debug.Log ("Projecting ball");
		byte[] send = new byte[1024];
		byte error;
		send [0] = 2;
		NetworkTransport.Send (socketId, connectionId, myUnreliableChannelId, send, send.Length, out error);
		Debug.Log (((NetworkError)error).ToString());
	}

	public void RequestUpdate(int id){
		NetworkMessage message = new NetworkMessage(2, id, null, null);
		/* 
		BinaryFormatter bf = new BinaryFormatter();
		using (MemoryStream ms = new MemoryStream(recBuffer))
		{
			data = bf.Deserialize(ms) as SerializeableTransform;
		}
		spawnmanager.SpawnObjectNetwork(data);
		*/

	}



	[System.Serializable]
    public class NetworkMessage{
        
		public byte type;
        public int? id;
        public byte? prefabId;

        public SerializeableTransform transform;

		public NetworkMessage(byte type, int? id, byte? prefabId, SerializeableTransform transform){
			this.type = type;
			this.id = id;
			this.prefabId = prefabId;
			this.transform = transform; 

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
}
