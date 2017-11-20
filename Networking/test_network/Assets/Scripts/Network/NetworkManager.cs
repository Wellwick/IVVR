using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour
{

    public static bool serverHosted = false;

    public GameObject buttonHost;
    public GameObject buttonClient;
    public GameObject buttonDisconnect;
    public LevelManager levelmanager;
    public string ipaddress;
    public int port;
    public static bool? isHost;


    private SpawnManager spawnmanager;
    private TcpListener serversocket;
    private TcpClient socket;
    private NetworkStream stream;

    // Use this for initialization
    void Start()
    {
        Button btnHost = buttonHost.GetComponent<Button>();
        Button btnClient = buttonClient.GetComponent<Button>();
        Button btnDisconnect = buttonDisconnect.GetComponent<Button>();
        spawnmanager = GameObject.FindObjectOfType<SpawnManager>();

    }

    void Update()
    {
        if (isHost == false) {
            if (stream.DataAvailable) {
                string data;
                BinaryFormatter bf = new BinaryFormatter();
                data = bf.Deserialize(stream) as string;
                Debug.Log(data);
            }

        } else if (isHost == true) {
            if (stream.DataAvailable) {
                string data;
                BinaryFormatter bf = new BinaryFormatter();
                data = bf.Deserialize(stream) as string;
                Debug.Log(data);
            }
        }
    }

    public void StartHost()
    {
        IPAddress localAddr = IPAddress.Parse(ipaddress);
        serversocket = new TcpListener(localAddr, port) as TcpListener;
        Debug.Log("created socket for server");

        serversocket.Start();

        TcpClient clientsocket = serversocket.AcceptTcpClient();

        // Get a stream object for reading and writing
        stream = clientsocket.GetStream();
        isHost = true;



    }

    public void StartClient()
    {
        IPAddress localAddr = IPAddress.Parse(ipaddress);
        TcpClient socket = new TcpClient();
        Debug.Log("created socket for client");

        Debug.Log("attemtpting to connect to server");
        socket.Connect(localAddr, port);

        stream = socket.GetStream();
        isHost = false;

    }


    public void SendSerializeableString(string message)
    {
        Debug.Log("sending message on network");
        Debug.Log(message);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(stream, message);



    }


    public void SendSerializeableTransform(GameObject spawnable)
    {
        Debug.Log("sending message on network");
        SerializeableTransform st = new SerializeableTransform(spawnable.transform);
        Debug.Log(st);
        BinaryFormatter bf = new BinaryFormatter();
        using (MemoryStream ms = new MemoryStream()) {
            bf.Serialize(ms, st);
            byte error;
            Debug.Log(ms.ToArray());
            Debug.Log(ms.ToArray().Length);


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
