using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Runtime.Serialization.Formatters.Binary;

public class NetworkManager : MonoBehaviour {
	
	bool serverHosted = false;
	int socketId;
	int connectionId;
    int unreliableChannel;

	// Use this for initialization
	void Start () {
		NetworkTransport.Init();
		Debug.Log("Network Initialised");

		ConnectionConfig config = new ConnectionConfig();
		unreliableChannel = config.AddChannel(QosType.Unreliable);
		HostTopology topology = new HostTopology(config, 2);
		int socketId = NetworkTransport.AddHost(topology, 7777);
		Debug.Log(socketId);

	}
	
	// Update is called once per frame
	void Update () {
		if (serverHosted)
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
                    serverHosted = true;
                    break;
                case NetworkEventType.DataEvent:
                    Debug.Log("Data Received");
                    break;
                case NetworkEventType.DisconnectEvent:
                    serverHosted = false;
                    Debug.Log("Disconnect Received");
                    Debug.Log(error);
					serverHosted = false;
					NetworkTransport.Disconnect(socketId, connectionId, out error);
                    break;
            }
        }
	}

    public void SendByte(byte[] data){
        if(serverHosted){
            byte error;
            NetworkTransport.Send(socketId, connectionId, unreliableChannel, data, 1, out error);
        }else{
            Debug.Log("Not so fast there boy, you ain't coneected yet \n You can't be sending " + data[0] + "'s to thin air, ya dingus");
        }
        
    }
    
    //for possible UI if we decide to add some extra tests 
    public void ShowUI(){


    }


}