using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using UnityEngine.XR.iOS;

public class TextManager : MonoBehaviour {

	public GameObject networkTextObject;
	public GameObject positionARKitObject;
	public GameObject rotationARKitObject;
	public GameObject positionTrackerObject;
	public GameObject rotationTrackerObject;
	public GameObject positionEngineObject;
	public GameObject rotationEngineObject;

	private UnityARCameraManager ARManager;
	private Text networkText;
	private Text positionARKitText;
	private Text rotationARKitText;
	private Text positionTrackerText;
	private Text rotationTrackerText;
	private Text positionEngineText;
	private Text rotationEngineText;


	// Use this for initialization
	void Start () {
		networkText = networkTextObject.GetComponent<Text> ();
		
		positionARKitText = positionARKitObject.GetComponent<Text>();
		rotationARKitText = rotationARKitObject.GetComponent<Text> ();
		positionTrackerText = positionTrackerObject.GetComponent<Text> ();
		rotationTrackerText = rotationTrackerObject.GetComponent<Text> ();
		positionEngineText = positionEngineObject.GetComponent<Text> ();
		rotationEngineText = rotationEngineObject.GetComponent<Text> ();

		positionARKitText.text = "ARKit Pos";
		rotationARKitText.text = "ARKit Rot";
		positionTrackerText.text = "Tracker Pos";
		rotationTrackerText.text = "Tracker Rot";
		positionEngineText.text = "Engine Pos";
		rotationEngineText.text = "Engine Rot";

		networkText.text = "Network Status";

		ARManager = GameObject.FindObjectOfType<UnityARCameraManager>();
	}

	// Update is called once per frame
	void Update () {
		Vector3 enginePosition = ARManager.getUnityCameraPosition ();
		Quaternion engineRotation = ARManager.getUnityCameraRotation (); //UnityARMatrixOps.GetRotation (UnityARSessionNativeInterface.lastTransform); 
		Vector4 ARKitPosition = ARManager.getARKitPosition ();
		Quaternion ARKitRotation = ARManager.getARKitRotation ();



		positionARKitText.text = "pos: {" + Math.Round(ARKitPosition.x, 2) + ", " + Math.Round(ARKitPosition.y, 2) + ", " + Math.Round(ARKitPosition.z, 2) + "}";
		rotationARKitText.text = "rot: {" + Math.Round(ARKitRotation.x, 2) + ", " + Math.Round(ARKitRotation.y, 2) + ", " + Math.Round(ARKitRotation.z, 2) + ", " + Math.Round(ARKitRotation.w, 2) + "}";
		positionEngineText.text = "pos: {" + Math.Round(enginePosition.x, 2) + ", " + Math.Round(enginePosition.y, 2) + ", " + Math.Round(enginePosition.z, 2) + "}";
		rotationEngineText.text = "rot: {" + Math.Round(engineRotation.x, 2) + ", " + Math.Round(engineRotation.y, 2) + ", " + Math.Round(engineRotation.z, 2) + ", " + Math.Round(engineRotation.w, 2) + "}";
	}

	public void changeNetworkString(String networkString) {
		networkText.text = networkString;
	}
	public void changeTrackerRotationString(Quaternion rot) {
		
		rotationTrackerText.text = "rot: {" + Math.Round (rot.x, 2) + ", " + Math.Round (rot.y, 2) + ", " + Math.Round (rot.z, 2) + ", " + Math.Round (rot.w, 2) + "}";
	}
	public void changeTrackerPositionString(Vector3 pos) {

		positionTrackerText.text = "rot: {" + Math.Round (pos.x, 2) + ", " + Math.Round (pos.y, 2) + ", " + Math.Round (pos.z, 2) + "}";
	}
}
