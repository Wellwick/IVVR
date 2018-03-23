using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthParticle : MonoBehaviour {

	public Transform camera;
	public Transform target;

	// Made use of Unity's Lerp page
	private float startTime;
	private Vector3 startPos;
	public float timeToTarget = 2.0f;



	// Use this for initialization
	void Start () {
		startTime = Time.time;	
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float timeToDate = Time.time - startTime;
		if (timeToDate >= timeToTarget) { 
			Destroy(gameObject);
			return;
		}
		transform.LookAt(camera.position, -Vector3.up);
		// Need to linearly interpolate to the moving enemy
		transform.position = Vector3.Lerp(startPos, target.position, timeToDate/timeToTarget);
	}
}
