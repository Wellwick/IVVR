using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	public GameObject spawnable;

	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		if (NetworkManager.serverHosted) {
			if (Input.GetMouseButtonDown(0)) {
				Vector3 objectPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				objectPos.z = 0f;
				Instantiate(spawnable, objectPos, Quaternion.identity);
			}
		}
	}
}
