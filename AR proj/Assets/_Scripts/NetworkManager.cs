using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkManager : MonoBehaviour {

	public static bool serverHosted = false;

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
				Debug.Log("Data Received");
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
}
