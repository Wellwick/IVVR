using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGrabObject : MonoBehaviour {

	private SteamVR_TrackedObject trackedObj;
	private GameObject collidingObject;
	private GameObject objectInHand;
	public GameObject firePrefab;
	private GameObject fire;
	public Rigidbody ballPrefab; //to throw
	
	// Update is called once per frame
	void Update () {
		if (Controller.GetHairTriggerDown()) {
			if (collidingObject)
				GrabObject();
			else
				SpawnFire();
		}
		if (Controller.GetHairTriggerUp()) {
			if (objectInHand)
				ReleaseObject();
			else
				RemoveFire();
		}

		if (fire.GetComponent<ParticleSystem>().isPlaying) {
			fire.transform.position = trackedObj.transform.position;
			fire.transform.rotation = trackedObj.transform.rotation;
		}
	}

	private SteamVR_Controller.Device Controller {
		get { return SteamVR_Controller.Input((int)trackedObj.index); }
	}

	void Awake() {
		trackedObj = GetComponent<SteamVR_TrackedObject>();
		//initialises fire and stops it
		fire = Instantiate(firePrefab, 
			trackedObj.transform.position, 
			Quaternion.identity) as GameObject;
		fire.GetComponent<ParticleSystem>().Stop(false, ParticleSystemStopBehavior.StopEmitting);
	}

	private void SetCollidingObject(Collider col) {
		if (collidingObject || !col.GetComponent<Rigidbody>())
			return;
		
		collidingObject = col.gameObject;
	}

	public void OnTriggerEnter(Collider other) {
		SetCollidingObject(other);
	}

	public void OnTriggerStay(Collider other) {
		SetCollidingObject(other);
	}

	public void OnTriggerExit(Collider other) {
		if (!collidingObject)
			return;
		
		collidingObject = null;
	}

	private void GrabObject() {
		objectInHand = collidingObject;
		collidingObject = null;

		var joint = AddFixedJoint();
		joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
	}

	private FixedJoint AddFixedJoint() {
		FixedJoint fx = gameObject.AddComponent<FixedJoint>();
		fx.breakForce = 20000;
		fx.breakTorque = 20000;
		return fx;
	}

	private void ReleaseObject() {
		if (GetComponent<FixedJoint>()) {
			GetComponent<FixedJoint>().connectedBody = null;
			Destroy(GetComponent<FixedJoint>());

			objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
			objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
		}

		objectInHand = null;
	}

	public void SpawnFire() {
		//set the fire prefab to the position and orientation of the controller and spawn the fire
		//fire.SetActive(true);
		//fireTransform = trackedObj.transform;
		fire.GetComponent<ParticleSystem>().Play(false);
	}

	public void RemoveFire() {
		fire.GetComponent<ParticleSystem>().Stop(false, ParticleSystemStopBehavior.StopEmitting);
	}

	//Throw a ball forwards
	public void throwBall(float speed){
		Rigidbody ball = (Rigidbody) Instantiate(ballPrefab,
			trackedObj.transform.position,
			Quaternion.identity); //Spawn ball in direction and location of controller
		ball.velocity = transform.forward * speed; //Give ball velocity forwards
	}
}
