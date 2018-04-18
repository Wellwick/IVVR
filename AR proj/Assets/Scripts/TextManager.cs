using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using UnityEngine.XR.iOS;

public class TextManager : MonoBehaviour {

	public GameObject networkTextObject;
	public GameObject framerateTextObject;
	public GameObject latencyTextObject;

	public GameObject positionARKitObject;
	public GameObject rotationARKitObject;
	public GameObject positionTrackerObject;
	public GameObject rotationTrackerObject;
	public GameObject positionEngineObject;
	public GameObject rotationEngineObject;

	private UnityARCameraManager ARManager;
	
	private Text networkText;
	private Text framerateText;
	private Text latencyText;

	private Text positionARKitText;
	private Text rotationARKitText;
	private Text positionTrackerText;
	private Text rotationTrackerText;
	private Text positionEngineText;
	private Text rotationEngineText;

	Queue<float> frameTimes;
	public int FrameQueueSize;

	// Use this for initialization
	void Start () {
		networkText = networkTextObject.GetComponent<Text>();
		framerateText = framerateTextObject.GetComponent<Text>();
		latencyText = latencyTextObject.GetComponent<Text>();

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

		frameTimes = new Queue<float>();
	}

	// Update is called once per frame
	void Update () {

		frameTimes.Enqueue(Time.time);

		float firstFrame = frameTimes.Peek();
		float framerate = 0;
		framerate = (frameTimes.Count) / (Time.time - firstFrame);
		
		changeFramerateString(String.Format("Framerate: {0:0.0}", framerate));

		if (frameTimes.Count > FrameQueueSize) {
			firstFrame = frameTimes.Dequeue();
		}

		Vector3 enginePosition = ARManager.getUnityCameraPosition ();
		Quaternion engineRotation = ARManager.getUnityCameraRotation (); //UnityARMatrixOps.GetRotation (UnityARSessionNativeInterface.lastTransform);
		Vector4 ARKitPosition = ARManager.getARKitPosition ();
		Quaternion ARKitRotation = ARManager.getARKitRotation ();

		positionARKitText.text = "pos: {" + Math.Round(ARKitPosition.x, 2) + ", " + Math.Round(ARKitPosition.y, 2) + ", " + Math.Round(ARKitPosition.z, 2) + "}";
		rotationARKitText.text = "rot: {" + Math.Round(ARKitRotation.x, 2) + ", " + Math.Round(ARKitRotation.y, 2) + ", " + Math.Round(ARKitRotation.z, 2) + ", " + Math.Round(ARKitRotation.w, 2) + "}";
		positionEngineText.text = "pos: {" + Math.Round(enginePosition.x, 2) + ", " + Math.Round(enginePosition.y, 2) + ", " + Math.Round(enginePosition.z, 2) + "}";
		rotationEngineText.text = "rot: {" + Math.Round(engineRotation.x, 2) + ", " + Math.Round(engineRotation.y, 2) + ", " + Math.Round(engineRotation.z, 2) + ", " + Math.Round(engineRotation.w, 2) + "}";
	}
	public void changeLatencyString(String latencyString) {
		latencyText.text = latencyString;
	}
	public void changeFramerateString(String framerateString) {
		framerateText.text = framerateString;
	}

	public void changeNetworkString(String networkString) {
		networkText.text = networkString;
	}
	public void updateTrackerRotationString(Quaternion rot) {

		rotationTrackerText.text = "rot: {" + Math.Round (rot.x, 2) + ", " + Math.Round (rot.y, 2) + ", " + Math.Round (rot.z, 2) + ", " + Math.Round (rot.w, 2) + "}";
	}
	public void updateTrackerPositionString(Vector3 pos) {

		positionTrackerText.text = "rot: {" + Math.Round (pos.x, 2) + ", " + Math.Round (pos.y, 2) + ", " + Math.Round (pos.z, 2) + "}";
	}
}
