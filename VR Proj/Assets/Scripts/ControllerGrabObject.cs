using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGrabObject : MonoBehaviour {

	private SteamVR_TrackedObject trackedObj;
	private GameObject collidingObject;
	private GameObject objectInHand;
	public GameObject firePrefab;
	private GameObject fire;
	
	// Update is called once per frame
	void Update () {
		if (Controller.GetHairTriggerDown() && collidingObject)
			GrabObject();

		if (Controller.GetHairTriggerDown() && !collidingObject)
			SpawnFire();

		if (Controller.GetHairTriggerUp())
			RemoveFire();

		if (Controller.GetHairTriggerUp() && objectInHand)
			ReleaseObject();

		if (fire) {
			fire.transform.position = trackedObj.transform.position;
			fire.transform.rotation = trackedObj.transform.rotation;
		}
	}

	private SteamVR_Controller.Device Controller {
		get { return SteamVR_Controller.Input((int)trackedObj.index); }
	}

	void Awake() {
		trackedObj = GetComponent<SteamVR_TrackedObject>();
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
		fire = Instantiate(firePrefab, 
			trackedObj.transform.position, 
			Quaternion.identity) as GameObject;

	}

	public void RemoveFire() {
		Destroy(fire);
	}
}
