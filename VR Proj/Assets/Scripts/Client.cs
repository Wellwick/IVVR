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
    public GameObject Camera;
    public GameObject spooker;

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
            networkInitialised = false;/* TODO For the time being! */
        }
        // VR device is no longer the one trying to connect
        /* BRING THIS BACK FOR PHONE */
        //connectionId = NetworkTransport.Connect(socketId, "137.205.112.42", 9090, 0, out error);
	}
	
	// Update is called once per frame
	void Update () {
		//test for buttons to do stuff! 
        /* GET RID OF THIS FOR PHONE */
        if (Input.GetKeyDown(KeyCode.A))
            Camera.GetComponent<shootBall>().throwBall();
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
                    break;
                case NetworkEventType.ConnectEvent: //AR connects
                    Debug.Log("Connection request from id: " + connectionId + " Received");
                    this.connectionId = connectionId;
                    break;
                case NetworkEventType.DataEvent:
                    Debug.Log("Data Received");
                    switch (recBuffer[0]){
                        case 0:
                            leftController.GetComponent<ControllerGrabObject>().RemoveFire();
						    rightController.GetComponent<ControllerGrabObject>().RemoveFire();
                            break;
                        case 1:
                            leftController.GetComponent<ControllerGrabObject>().SpawnFire();
						    rightController.GetComponent<ControllerGrabObject>().SpawnFire();
                            break;
                        case 2:
                            Camera.GetComponent<shootBall>().throwBall(); //shootBall.cs is on camera(eyes) shoots ball in direction facing.
                            break;
                        case 3:
                            Camera.GetComponent<wallDemo>().spawnWall();
                            break;
                        case 4:
                            Camera.GetComponent<wallDemo>().demolishWall();
                            break;
                        case 5:
                            spooker.GetComponent<Spook>().spookPlayer();
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
}
