using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using UnityEngine.XR.iOS;

public class TextManager : MonoBehaviour {

	public GameObject networkTextObject;
	public GameObject framerateTextObject;
	public GameObject gameStateTextObject;

	public GameObject positionARKitObject;
	public GameObject rotationARKitObject;
	public GameObject positionTrackerObject;
	public GameObject rotationTrackerObject;
	public GameObject positionEngineObject;
	public GameObject rotationEngineObject;

	public GameObject playerHealthObject;
	public GameObject hengeObject;

	private PlayerHealth playerHealth;
	private Henge henge;
	private UnityARCameraManager ARManager;
	
	private Text networkText;
	private Text framerateText;
	private Text gameStateText;

	private Text positionARKitText;
	private Text rotationARKitText;
	private Text positionTrackerText;
	private Text rotationTrackerText;
	private Text positionEngineText;
	private Text rotationEngineText;

	//Queue<float> frameTimes;
	//public int FrameQueueSize;

	private float fpsDelay = 1.0f;
	private float deltaTime = 0.0f;
	private float fpsmin = float.MaxValue;
	private float fpsavg = 0.0f;
	private float fpsmax = 0.0f;
	private float frametimecount = 0.0f;
	private float frametimetotal = 0.0f;

	private int latency = 0;
	private String networkStatus;

	// Use this for initialization
	void Start () {
		networkText = networkTextObject.GetComponent<Text>();
		framerateText = framerateTextObject.GetComponent<Text>();
		gameStateText = gameStateTextObject.GetComponent<Text>();

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
		playerHealth = playerHealthObject.GetComponent<PlayerHealth>();
		henge = hengeObject.GetComponent<Henge>();

		//frameTimes = new Queue<float>();
	}


	/*
	private float getFramerate() {
	//OLD Framerate calculation
	frameTimes.Enqueue(Time.time);
	float firstFrame = frameTimes.Peek();
	float framerate = 0;
	
	changeFramerateString(String.Format("Framerate:\t{0:0}fps\nNetwork:\t{1:0}ms", framerate, latency));

	if (frameTimes.Count > FrameQueueSize) {
		framerate = (frameTimes.Count) / (Time.time - firstFrame);
		frameTimes.Dequeue();
	}
	return framerate;
	}*/

	// Update is called once per frame
	void Update () {
		//Arrays of strings displayed as debug information
		String[] psDebug = new String[3];	//performance stats debug
		String[] gsDebug = new String[4];	//game state debug

		deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

		if (fpsDelay > 0) {
			fpsDelay -= Time.deltaTime;
			return;
		}

		//deltaTime = Time.deltaTime;
		float msec = deltaTime * 1000.0f;
		float fps = (1.0f / deltaTime);

		if (fps > fpsmax) {
			fpsmax = fps;
		}
		if (fps < fpsmin) {
			fpsmin = fps;
		}

		frametimetotal += deltaTime;
		frametimecount++;
		fpsavg = (frametimecount / frametimetotal);

		if (frametimecount > 64000) {
			//reset?
		}

		psDebug[0] = String.Format("{0,-12}{1:0.0} ms ({2:0} fps)", "Framerate:", msec, fps);
		//psDebug[1] = String.Format("{0}\t{1})", frametimetotal, frametimecount);
		psDebug[1] = String.Format("{0,-12}{1:0.0}/{2:0.0}/{3:0.0}"  ,"Min/Avg/Max:", fpsmin, fpsavg, fpsmax);
		psDebug[2] = String.Format("{0,-12}{1}", "Network:", networkStatus);


		//Update Player health, Rune completion, Allies, Enemies debug text
		//Apart from player health, probably do not want to be doing these calculations every frame
		//Consider updating those every x seconds
		String ph = String.Format("{0:0}%", ((float)playerHealth.currentHealth / (float)playerHealth.maxHealth) * 100.0f);
		//String rs = String.Format("{0:0}%", (henge.getActiveRunes() / henge.getSize()) * 100);
		String rs = henge.getActiveRunes() + "/" + henge.getSize();
		int allies = FindObjectsOfType<Eyeball>().Length + 1;
		int enemies = FindObjectsOfType<EnemyHealth>().Length;

		gsDebug[0] = String.Format("Player:{0,5}", ph);
		gsDebug[1] = String.Format("Henge:{0,5}", rs);
		gsDebug[2] = String.Format("Allies:{0,5}", allies);
		gsDebug[3] = String.Format("Enemies:{0,5}", enemies);

		changeFramerateString(psDebug[0] + "\n" + psDebug[1] + "\n" + psDebug[2]);//+ "\n" + psDebug[3]);
		changeGameStatusString(gsDebug[0] + "\n" + gsDebug[1] + "\n" + gsDebug[2] + "\n" + gsDebug[3]);



		//Debug text for engine, ARKit positions and rotations
		Vector3 enginePosition = ARManager.getUnityCameraPosition ();
		Vector4 ARKitPosition = ARManager.getARKitPosition ();
		//Quaternion engineRotation = ARManager.getUnityCameraRotation (); //UnityARMatrixOps.GetRotation (UnityARSessionNativeInterface.lastTransform);
		//Quaternion ARKitRotation = ARManager.getARKitRotation ();
		Vector3 engineRotation = ARManager.getUnityCameraRotation ().eulerAngles;
		Vector3 ARKitRotation = ARManager.getARKitRotation ().eulerAngles;

		/*
 		positionARKitText.text = "pos: {" + Math.Round(ARKitPosition.x, 2) + ", " + Math.Round(ARKitPosition.y, 2) + ", " + Math.Round(ARKitPosition.z, 2) + "}";
		rotationARKitText.text = "rot: {" + Math.Round(ARKitRotation.x, 2) + ", " + Math.Round(ARKitRotation.y, 2) + ", " + Math.Round(ARKitRotation.z, 2) + "}";
		positionEngineText.text = "pos: {" + Math.Round(enginePosition.x, 2) + ", " + Math.Round(enginePosition.y, 2) + ", " + Math.Round(enginePosition.z, 2) + "}";
		rotationEngineText.text = "rot: {" + Math.Round(engineRotation.x, 2) + ", " + Math.Round(engineRotation.y, 2) + ", " + Math.Round(engineRotation.z, 2) + "}";
		*/
		positionARKitText.text = String.Format("pos: ({0:0.0}, {1:0.0}, {2:0.0})", ARKitPosition.x, ARKitPosition.y, ARKitPosition.z);
		rotationARKitText.text = String.Format("rot: ({0:000}, {1:000}, {2:000})", ARKitRotation.x, ARKitRotation.y, ARKitRotation.z);
		positionEngineText.text = String.Format("pos: ({0:0.0}, {1:0.0}, {2:0.0})", enginePosition.x, enginePosition.y, enginePosition.z);
		rotationEngineText.text = String.Format("rot: ({0:000}, {1:000}, {2:000})", engineRotation.x, engineRotation.y, engineRotation.z);
	}
	public void updateLatency(int latency) {
		this.latency = latency;
	}
	public void changeFramerateString(String framerateString) {
		framerateText.text = framerateString;
	}

	public void changeGameStatusString(String gameStatus) {
		gameStateText.text = gameStatus;
	}

	public void updateNetworkString(String networkString) {
		networkText.text = networkString;
		networkStatus = networkString;
	}
	public void updateTrackerRotationString(Quaternion rot) {
		Vector3 rotVec = rot.eulerAngles;
		rotationTrackerText.text = String.Format("pos: ({0:000}, {1:000}, {2:000})", rotVec.x, rotVec.y, rotVec.z);
	}
	public void updateTrackerPositionString(Vector3 pos) {
		positionTrackerText.text = String.Format("pos: ({0:0.0}, {1:0.0}, {2:0.0})", pos.x, pos.y, pos.z);
	}
}
