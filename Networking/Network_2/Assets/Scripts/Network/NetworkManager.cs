using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour
{

    public static bool serverHosted = false;

    public GameObject buttonHost;
    public GameObject buttonClient;
    public GameObject buttonDisconnect;
    public LevelManager levelmanager;

    private int socketId;
    private int connectionId;
    private int myReliableChannelId;
    private int myUnreliableChannelId;
    private SpawnManager spawnmanager;
    private bool networkInitialised;

    // Use this for initialization
    void Start()
    {
        Button btnHost = buttonHost.GetComponent<Button>();
        Button btnClient = buttonClient.GetComponent<Button>();
        Button btnDisconnect = buttonDisconnect.GetComponent<Button>();
        spawnmanager = GameObject.FindObjectOfType<SpawnManager>();
        networkInitialised = false;

    }

    // Update is called once per frame
    void Update()
    {
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
                    break;
                case NetworkEventType.DataEvent:
                    SerializeableTransform data;
                    Debug.Log("Data Received");
                    BinaryFormatter bf = new BinaryFormatter();
                    using (MemoryStream ms = new MemoryStream(recBuffer))
                    {
                        data = bf.Deserialize(ms) as SerializeableTransform;
                    }
                    spawnmanager.SpawnObjectNetwork(data);

                    break;
                case NetworkEventType.DisconnectEvent:
                    serverHosted = false;
                    Debug.Log("Disconnect Received");
                    Debug.Log(error);
                    levelmanager.LoadLevel(SceneManager.GetActiveScene().name);
                    Debug.Log("The error was: " + ((NetworkError)error).ToString());
                    break;
            }
        }

    }

    public void StartHost()
    {
        buttonHost.SetActive(false);
        buttonClient.SetActive(false);
        Debug.Log("Cleared UI");
        if (!networkInitialised)
        {
            NetworkTransport.Init();
            Debug.Log("Host Started");
            ConnectionConfig config = new ConnectionConfig();
            int myReiliableChannelId = config.AddChannel(QosType.ReliableSequenced);
            HostTopology topology = new HostTopology(config, 2);
            int socketId = NetworkTransport.AddHost(topology, 9090);
            Debug.Log(socketId);
            networkInitialised = true;
        }

        serverHosted = true;

    }


    public void StartClient()
    {
        buttonHost.SetActive(false);
        buttonClient.SetActive(false);
        Debug.Log("Cleared UI");
        buttonDisconnect.SetActive(true);

        if (!networkInitialised)
        {
            NetworkTransport.Init();
            Debug.Log("Host Started");

            ConnectionConfig config = new ConnectionConfig();
            myReliableChannelId = config.AddChannel(QosType.ReliableSequenced);
            HostTopology topology = new HostTopology(config, 2);
            int socketId = NetworkTransport.AddHost(topology);
            Debug.Log(socketId);
            networkInitialised = true;
        }
        byte error;
        int connectionId = NetworkTransport.Connect(socketId, "188.223.171.115", 7777, 0, out error);

        SendSerializeableString("hello");
        Debug.Log(error);
        serverHosted = true;

    }

    public void StartDisconnect()
    {
        serverHosted = false;
        byte error;
        NetworkTransport.Disconnect(socketId, connectionId, out error);
        Debug.Log("Disconnected");
        levelmanager.LoadLevel(SceneManager.GetActiveScene().name);
    }

    public void SendSerializeableString(string message) {
        Debug.Log("sending message on network");
        Debug.Log(message);
        BinaryFormatter bf = new BinaryFormatter();
        using (MemoryStream ms = new MemoryStream())
        {
            bf.Serialize(ms, message);
            byte error;
            Debug.Log(ms.ToArray());
            Debug.Log(ms.ToArray().Length);
            NetworkTransport.Send(socketId, connectionId, myReliableChannelId, ms.ToArray(), 1024, out error);


        }


    }

    public void SendSerializeableTransform(GameObject spawnable)
    {
        Debug.Log("sending message on network");
        SerializeableTransform st = new SerializeableTransform(spawnable.transform);
        Debug.Log(st);
        BinaryFormatter bf = new BinaryFormatter();
        using (MemoryStream ms = new MemoryStream())
        {
            bf.Serialize(ms, st);
            byte error;
            Debug.Log(ms.ToArray());
            Debug.Log(ms.ToArray().Length);
            NetworkTransport.Send(socketId, connectionId, myReliableChannelId, ms.ToArray(), 1024, out error);


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


        public SerializeableTransform(Transform transform)
        {
            posX = transform.position.x;
            posY = transform.position.y;
            posZ = transform.position.z;
            rotX = transform.rotation.x;
            rotY = transform.rotation.y;
            rotZ = transform.rotation.z;
        }

        public override string ToString()
        {
            return "x = " + posX + "\ny = " + posY + "\nz = " + posZ;
        }

    }


}
