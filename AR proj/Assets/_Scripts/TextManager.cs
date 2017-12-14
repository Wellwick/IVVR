using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using UnityEngine.XR.iOS;

public class TextManager : MonoBehaviour {

	public GameObject positionTextObject;
	public GameObject networkTextObject;
	public GameObject rotationARKitObject;
	public GameObject rotationTrackerObject;
	public GameObject rotationEngineObject;

	private UnityARCameraManager ARManager;
	private Text networkText;
	private Text positionText;
	private Text rotationARKitText;
	private Text rotationTrackerText;
	private Text rotationEngineText;


	// Use this for initialization
	void Start () {
		positionText = positionTextObject.GetComponent<Text>();
		networkText = networkTextObject.GetComponent<Text> ();
		rotationARKitText = rotationARKitObject.GetComponent<Text> ();
		rotationTrackerText = rotationTrackerObject.GetComponent<Text> ();
		rotationEngineText = rotationEngineObject.GetComponent<Text> ();
		positionText.text = "Updating position text...";
		networkText.text = "Updating network text...";
		rotationARKitText.text = "Updating ARKit rotation...";
		rotationTrackerText.text = "Updating Tracker rotation...";
		rotationEngineText.text = "Retrieving engine rotation...";

		ARManager = GameObject.FindObjectOfType<UnityARCameraManager>();
	}

	// Update is called once per frame
	void Update () {
		Vector3 position = ARManager.getPosition ();
		Quaternion arKitRotation = UnityARMatrixOps.GetRotation (UnityARSessionNativeInterface.lastTransform); 
		Quaternion engineRotation = ARManager.getRotation ();
		positionText.text = "Engine pos: {" + Math.Round(position.x, 2) + ", " + Math.Round(position.y, 2) + ", " + Math.Round(position.z, 2) + "}";
		rotationEngineText.text = "Engine rot: {" + Math.Round(engineRotation.x, 2) + ", " + Math.Round(engineRotation.y, 2) + ", " + Math.Round(engineRotation.z, 2) + ", " + Math.Round(engineRotation.w, 2) + "}";
		rotationARKitText.text = "ARKit: {" + Math.Round(arKitRotation.x, 2) + ", " + Math.Round(arKitRotation.y, 2) + ", " + Math.Round(arKitRotation.z, 2) + ", " + Math.Round(arKitRotation.w, 2) + "}";
	}

	public void changeNetworkString(String networkString) {
		networkText.text = networkString;
	}
	public void changeTrackerRotationString(Quaternion rot) {
		
		rotationTrackerText.text = "Tracker: {" + Math.Round (rot.x, 2) + ", " + Math.Round (rot.y, 2) + ", " + Math.Round (rot.z, 2) + ", " + Math.Round (rot.w, 2) + "}";
	}
}
