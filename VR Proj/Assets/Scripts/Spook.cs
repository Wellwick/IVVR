using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spook : MonoBehaviour {
	public GameObject skull; //It is a Canvas set to appear and fill screen
	private GameObject skullClone;
	public GameObject cam; 
	private int x = 31;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (x < 30){
			x = x + 1;
		} else if (x == 30){
			Destroy(skullClone); //Remove after 30 frames (1 second)
			x = x + 1;
		}
	}

	public void spookPlayer(){
		skullClone = Instantiate(skull) as GameObject;
		x = 0; //Start timer to remove after one second
	}
}
