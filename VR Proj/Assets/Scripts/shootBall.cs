using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootBall : MonoBehaviour {
	public GameObject ballPrefab;

	private Prefabs prebabs;
	private int y = 0;

	public void throwBall(int prefabId) {
		prebabs = GameObject.FindObjectOfType<Prefabs>();
		GameObject ball = Instantiate(prebabs.prefabs[prefabId],transform.position,transform.rotation) as GameObject;
		ball.GetComponent<Rigidbody>().velocity = transform.forward * 10f;
		GameObject.FindObjectOfType<NetworkManager>().addObject(ball, Prefabs.PID.Ball);
	}

	// Update is called once per frame
	void Update () {
	}
}
