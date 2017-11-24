using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootBall : MonoBehaviour {
	public GameObject ballPrefab;
	public GameObject cam;

	private Prefabs prebabs;
	private int y = 0;

	public void throwBall(int prefabId) {
		prebabs = GameObject.FindObjectOfType<Prefabs>();
		GameObject ball = Instantiate(prebabs.prefabs[prefabId],cam.transform.position,cam.transform.rotation) as GameObject;
		ball.GetComponent<Rigidbody>().velocity = cam.transform.forward * 10f;
		GameObject.FindObjectOfType<NetworkManager>().addObject(ball, Prefabs.PID.Ball);
	}

	// Update is called once per frame
	void Update () {
	}
}
