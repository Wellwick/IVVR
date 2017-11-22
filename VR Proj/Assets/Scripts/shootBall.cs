using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootBall : MonoBehaviour {
	public Rigidbody ballPrefab;
	private int y = 0;

	public void throwBall() {
		Rigidbody ball = (Rigidbody) Instantiate(ballPrefab,transform.position,transform.rotation);
		ball.velocity = transform.forward * 10f;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
