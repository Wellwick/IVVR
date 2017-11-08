using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour {

	public static bool serverHosted = false;

	public GameObject buttonHost;
	public GameObject buttonClient;
	public GameObject buttonDisconnect;

	private int socketId;
	private int hostId;
	private int connectionId;
	private int myReliableChannelId;
	private int myUnreliableChannelId;

	// Use this for initialization
	void Start() {
		Button btnHost = buttonHost.GetComponent<Button>();
		Button btnClient = buttonClient.GetComponent<Button>();
		Button btnDisconnect = buttonDisconnect.GetComponent<Button>();


	}

	// Update is called once per frame
	void Update() {
		if (serverHosted) {
			int recHostId;
			int connectionId;
			int channelId;
			byte[] recBuffer = new byte[1024];
			int bufferSize = 1024;
			int dataSize;
			byte error;
			NetworkEventType recData = NetworkTransport.Receive(out recHostId, out connectionId, out channelId, recBuffer, bufferSize, out dataSize, out error);
			switch (recData) {
				case NetworkEventType.Nothing:
					break;
				case NetworkEventType.ConnectEvent:
					Debug.Log("Connection request from id: " + connectionId + " Received");
					break;
				case NetworkEventType.DataEvent:
					Debug.Log("Data Received");
					break;
				case NetworkEventType.DisconnectEvent:
					Debug.Log("Disconnect Received");
					break;
			}
		}

	}

	public void StartHost() {
		buttonHost.SetActive(false);
		buttonClient.SetActive(false);
		Debug.Log("Cleared UI");

		NetworkTransport.Init();
		Debug.Log("Host Started");

		ConnectionConfig config = new ConnectionConfig();
		int myReiliableChannelId = config.AddChannel(QosType.Reliable);
		int myUnreliableChannelId = config.AddChannel(QosType.Unreliable);
		HostTopology topology = new HostTopology(config, 1);
		int socketId = NetworkTransport.AddHost(topology, 7777);
		Debug.Log(socketId);

		serverHosted = true;



	}

	public void StartClient() {
		buttonHost.SetActive(false);
		buttonClient.SetActive(false);
		Debug.Log("Cleared UI");

		buttonDisconnect.SetActive(true);

		NetworkTransport.Init();
		Debug.Log("Host Started");

		ConnectionConfig config = new ConnectionConfig();
		myReliableChannelId = config.AddChannel(QosType.Reliable);
		myUnreliableChannelId = config.AddChannel(QosType.Unreliable);
		HostTopology topology = new HostTopology(config, 1);
		int socketId = NetworkTransport.AddHost(topology, 55607);
		Debug.Log(socketId);

		byte error;
		int connectionId = NetworkTransport.Connect(socketId, "127.0.0.1", 7777, 0, out error);
		Debug.Log("Connected to server. ConnectionId: " + connectionId);
		serverHosted = true;

	}

	public void StartDisconnect() {
		serverHosted = false;
		buttonDisconnect.SetActive(false);
		byte error;
		NetworkTransport.Disconnect(hostId, connectionId, out error);
		Debug.Log("Disconnected");

		buttonHost.SetActive(true);
		buttonClient.SetActive(true);
	}

	public void SendSerializeableTransform(Transform transfom) {
		SerializeableTransform serializeableTransform = new SerializeableTransform(transform);
		BinaryFormatter bf = new BinaryFormatter();
		using (MemoryStream ms = new MemoryStream()) {
			bf.Serialize(ms, serializeableTransform);
			byte error;
			Debug.Log(ms.ToArray());
			Debug.Log(ms.ToArray().Length);
			//NetworkTransport.Send(hostId, connectionId, myReliableChannelId, ms.ToArray(), ms.ToArray().Length, out error);


		}


	}

	[System.Serializable]
	private class SerializeableTransform {

		[SerializeField]
		private Vector3 position;
		private Quaternion rotation;

		public SerializeableTransform(Transform transform) {
			this.position = transform.position;
			this.rotation = transform.rotation;
		}

		public Vector3 GetPosition() {
			return position;
		}

		public Quaternion GetQuaternion() {
			return rotation;
		}
	}


}
