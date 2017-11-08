using UnityEngine;

public class SpawnManager : MonoBehaviour {

	public GameObject spawnable;
	public NetworkManager networkmanager;

	// Use this for initialization
	void Start() {
		networkmanager = GameObject.FindObjectOfType<NetworkManager>();

	}

	// Update is called once per frame
	void Update() {
		if (NetworkManager.serverHosted) {
			if (Input.GetMouseButtonDown(0)) {
				Vector3 objectPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				objectPos.z = 0f;
				GameObject cube = Instantiate(spawnable, objectPos, Quaternion.identity) as GameObject;
				networkmanager.SendSerializeableTransform(cube.transform);
			}
		}
	}
}


