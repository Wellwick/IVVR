using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallDemo : MonoBehaviour {
	public GameObject wallPrefab;
	private GameObject wall;
	public Rigidbody ballPrefab;
	private Rigidbody ball;
	public GameObject cam;
	private int x = 400;
	private Transform wallSpot;
	private Quaternion wallRot;
	private bool removeWall = false;

	void Start(){
	}

	// Update is called once per frame
	void Update () {
		if (removeWall){
			if (x == 0){
				killWall();
				removeWall = false;
			} 
			x = x-1;
		}
	}


	public void spawnWall() {
		wall = Instantiate(wallPrefab,cam.transform.forward * 4,cam.transform.rotation) as GameObject;
		wallSpot = cam.transform;
		wallRot = cam.transform.rotation;
		// TODO need to add all children of this to gameObject, each of which are a brick
		x = 400;
	}

	public void demolishWall(){
		ball = Instantiate(ballPrefab,new Vector3 (wallSpot.position.x,wallSpot.position.y,wallSpot.forward.z),wallRot);
		ball.velocity = wallSpot.forward * 10f;
		removeWall = true;
	}

	public void killWall(){
		Destroy(wall);
		Destroy(ball.gameObject);
	}
}
