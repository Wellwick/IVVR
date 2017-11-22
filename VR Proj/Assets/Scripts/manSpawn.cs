using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manSpawn : MonoBehaviour {
	public GameObject manPrefab;
	private GameObject man2;
	private int x = 0;
	private int y = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (y == 0){
			man2 = Instantiate(manPrefab,
				new Vector3(0,2,1),
				Quaternion.identity) as GameObject;
		}
		y = y+1;
		if (y == 50){
			Destroy(man2);
		}
		if (y == 100){
			y = 0;
		}
	}
}
