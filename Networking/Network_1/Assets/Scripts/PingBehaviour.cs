using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class PingBehaviour : NetworkBehaviour {
	public float timeTillDie;

	private float startTime;

	// Use this for initialization
	void Start () {
		startTime = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeSinceLevelLoad - startTime >= timeTillDie) {
			Destroy(gameObject);
		}
		
	}
}
