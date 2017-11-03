using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ObserverController : NetworkBehaviour {
	public Camera cam;

	public GameObject pingObject;

	// Use this for initialization
	void Start () {
        Debug.Log("Observer Entered the World");
		if (!isLocalPlayer) {
			cam.enabled = false;
		} else {
			cam.enabled = true;
		}

}
	
	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer) {
			return;
		}

		if (Input.GetMouseButtonDown(0)) {
			Debug.Log("Pressed left click.");
			CmdSpawnPing();
			Debug.Log("ping at " + Input.mousePosition);
		}
	}

	[Command]
	void CmdSpawnPing () {
		Ray ray;
		RaycastHit hit;
		ray = cam.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit, 100.0f)) {
			Debug.Log(hit.collider.name);
			if (hit.collider.name == "Plane") {

				var ping = Instantiate(pingObject, hit.point, Quaternion.identity) as GameObject;
				NetworkServer.Spawn(ping);
			}
		}
	}
}




