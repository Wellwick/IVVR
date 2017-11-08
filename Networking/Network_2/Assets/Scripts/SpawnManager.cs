using UnityEngine;

public class SpawnManager : MonoBehaviour {

	public static SpawnManager instance;

	public GameObject spawnable;
	public NetworkManager networkmanager;
	// Use this for initialization
	void Start() {
		networkmanager = GameObject.FindObjectOfType<NetworkManager>();
		if (instance == null) {
			DontDestroyOnLoad(this);
			instance = this;
		} else {
			Destroy(this);
		}

	}

	// Update is called once per frame
	void Update() {
		if (NetworkManager.serverHosted) {
			if (Input.GetMouseButtonDown(0)) {
				Vector3 objectPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				objectPos.z = 0f;
				GameObject cube = Instantiate(spawnable, objectPos, Quaternion.identity) as GameObject;
				Debug.Log("Cube position = " + cube.transform.position);
				if (NetworkManager.serverHosted) {
					networkmanager.SendSerializeableTransform(cube);
				}
			}
		}
	}


	public void SpawnObjectNetwork(NetworkManager.SerializeableTransform st) {
		Debug.Log("spawning object from network");
		Debug.Log(st);
		Vector3 pos = new Vector3(st.posX, st.posY, st.posZ);
		Instantiate(spawnable, pos, Quaternion.identity);

	}
}


