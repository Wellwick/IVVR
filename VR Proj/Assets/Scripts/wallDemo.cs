using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallDemo : MonoBehaviour {
	public GameObject wallPrefab;
	private GameObject wall;
	public Rigidbody ballPrefab;
	private Rigidbody ball;
	private int x = 50;


	// Update is called once per frame
	void Update () {
	}

	public void spawnWall() {
		wall = Instantiate(wallPrefab,new Vector3(0,0,6),Quaternion.identity) as GameObject;
	}

	public void killWall(){
		Destroy(wall);
	}
}
