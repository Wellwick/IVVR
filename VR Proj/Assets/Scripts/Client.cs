using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Client : MonoBehaviour {

	public static bool serverHosted = false;

	private int socketId;
	private int hostId;
	private int connectionId;
	private int myReliableChannelId;
	private int myUnreliableChannelId;
	private bool networkInitialised;

	public GameObject leftController;
	public GameObject rightController;

	// Use this for initialization
	void Start () {
        networkInitialised = false;

        if (!networkInitialised)
        {
            NetworkTransport.Init();
            Debug.Log("Host Started");

            ConnectionConfig config = new ConnectionConfig();
            myUnreliableChannelId = config.AddChannel(QosType.Unreliable);
            HostTopology topology = new HostTopology(config, 2);
            socketId = NetworkTransport.AddHost(topology);
            Debug.Log(socketId);
            networkInitialised = true;
        }
        byte error;
        connectionId = NetworkTransport.Connect(socketId, "188.223.171.115", 7777, 0, out error);
	}
	
	// Update is called once per frame
	void Update () {
		if (networkInitialised)
        {
            int recHostId;
            int connectionId;
            int channelId;
            byte[] recBuffer = new byte[1024];
            int bufferSize = 1024;
            int dataSize;
            byte error;
            NetworkEventType recData = NetworkTransport.Receive(out recHostId, out connectionId, out channelId, recBuffer, bufferSize, out dataSize, out error);
            switch (recData)
            {
                case NetworkEventType.Nothing:
                    break;
                case NetworkEventType.ConnectEvent:
                    Debug.Log("Connection request from id: " + connectionId + " Received");
                    this.connectionId = connectionId;
                    break;
                case NetworkEventType.DataEvent:
                    Debug.Log("Data Received");
                    if (recBuffer[0] == 0) {
						leftController.GetComponent<ControllerGrabObject>().RemoveFire();
						rightController.GetComponent<ControllerGrabObject>().RemoveFire();
					} else if (recBuffer[0] == 1) {
						leftController.GetComponent<ControllerGrabObject>().SpawnFire();
						rightController.GetComponent<ControllerGrabObject>().SpawnFire();
					}

                    break;
                case NetworkEventType.DisconnectEvent:
                    networkInitialised = false;
					Debug.Log("Disconnect Received");
                    break;
            }
        }
	}
}
