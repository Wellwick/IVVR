﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : MonoBehaviour {

	private SteamVR_TrackedObject trackedObj;
	public GameObject grapplePrefab;
	private GameObject grapple;
	private Transform grappleTransform;

	public LayerMask grappleMask;
	private bool shouldPull;

	private GameObject pullObject;
	private bool pull = false;
	private bool holding = false;

	public float speed = 8.0f;
	
	// Use this for initialization
	void Start () {
		grapple = Instantiate(grapplePrefab);
		grappleTransform = grapple.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad)) {
			RaycastHit hit;


			if (Physics.Raycast(trackedObj.transform.position, transform.forward, out hit, 100, 
					grappleMask)) {
				ShowGrapple(hit);
				shouldPull = true;
				pullObject = hit.transform.gameObject;
			}
		} else {
			grapple.SetActive(false);
			shouldPull = false;
		}
		
		if (Controller.GetHairTriggerDown() && shouldPull) {
			pull = true;
		}
		if (pull) {
			float step = speed * Time.deltaTime;
			pullObject.transform.position = Vector3.MoveTowards(pullObject.transform.position, 
												trackedObj.transform.position, step);
			if (Vector3.Distance(pullObject.transform.position,trackedObj.transform.position)<0.3f) {
				//treat this as a grab
				GrabObject();
				pull = false;
				shouldPull = false;
			}
		}
		if (Controller.GetHairTriggerUp()) {
			pull = false;
			if (holding) ReleaseObject();
		}
	}

	private SteamVR_Controller.Device Controller {
		get { return SteamVR_Controller.Input((int)trackedObj.index); }
	}

	void Awake() {
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}

	private void ShowGrapple(RaycastHit hit) {
		grapple.SetActive(true);

		grappleTransform.position = Vector3.Lerp(trackedObj.transform.position, hit.point, .5f);
		grappleTransform.LookAt(hit.point);
		grappleTransform.localScale = new Vector3(grappleTransform.localScale.x, grappleTransform.localScale.y,
			hit.distance);

	}

	private void GrabObject() {
		var joint = AddFixedJoint();
		joint.connectedBody = pullObject.GetComponent<Rigidbody>();
		holding = true;
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

			pullObject.GetComponent<Rigidbody>().velocity = Controller.velocity;
			pullObject.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
		}

		pullObject = null;
		holding = false;
	}
}