using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkInterface : MonoBehaviour {

	public GameObject HealBeamObject;
	public GameObject DamageBeamObject;
	public GameObject VRPlayer;
	public Text IPinputFieldObject;

	private static GameManager gameManager;
	private static Shooting shooting;
	private static Text IPinputField;
	private static UnityARCameraManager ARCameraManager;
	private static TextManager textManager;
	private static Beam HealBeam;
	private static Beam DamageBeam;

	private static Vector3 headsetPos;
	private static Vector3 trackerPos;
	private static Quaternion headsetRot;
	private static Quaternion trackerRot;

	void Start() {

		//Debug.Log ("Starting Network Interface... <TextManager found>:" + (textManager != null) + " <ARCameraManager found>:" + (ARCameraManager != null));
		HealBeam = HealBeamObject.GetComponent<Beam>();
		DamageBeam = DamageBeamObject.GetComponent<Beam>();

		gameManager = FindObjectOfType<GameManager>();
		ARCameraManager = FindObjectOfType<UnityARCameraManager>();
		textManager = FindObjectOfType<TextManager> ();

		IPinputField = IPinputFieldObject;
	}

	void Update() {
		
	}

	public static int getBeamType(){
		if (HealBeam.isEmitting()) {
			return 2;
		} else if (DamageBeam.isEmitting()) {
			return 1;
		} else {
			return 0;
		}

	}
	public static void UpdateGameState(GameState gameState) {
		
		gameManager.HandleGameStateChanged(gameState);
	}



	

	public static void UpdateNetworkStatus(string status) {

		if (textManager != null) {

			textManager.updateNetworkString (status);
			//textManager.changeLatencyString (status);

		} else {

			Debug.LogError ("Attempting to update network status but textManager is null.");

		}
	}

	public static Transform GetCameraTransform() {
		if (ARCameraManager != null) {
			return ARCameraManager.GetUnityCameraTransform();

		} else {

			Debug.LogError ("Attempting to retrieve Unity camera transform but ARCameraManager is null.");

		}
		return null;
	}
	public static Vector3 GetCameraPosition() {
		if (ARCameraManager != null) {
			return ARCameraManager.getUnityCameraPosition();

		} else {

			Debug.LogError ("Attempting to retrieve Unity camera position but ARCameraManager is null.");

		}
		return new Vector3();
	}
	public static Quaternion getCameraRotation() {
		if (ARCameraManager != null) {
			return ARCameraManager.getUnityCameraRotation();

		} else {

			Debug.LogError ("Attempting to retrieve Unity camera rotation but ARCameraManager is null.");

		}
		return new Quaternion();
	}
	public static void UpdateTrackerPose(Vector3 pos, Quaternion rot) {

		if (ARCameraManager == null) {
			ARCameraManager = FindObjectOfType<UnityARCameraManager>();
		}

		if (ARCameraManager != null) {

			ARCameraManager.updateTrackerPosition (pos);
			ARCameraManager.updateTrackerRotation (rot);

			textManager.updateTrackerPositionString (pos, headsetPos);
			textManager.updateTrackerRotationString (rot, headsetRot);

		} else {

			Debug.LogError ("Attempting to update tracker pose but ARCameraManager is null.");

		}
	}
	public static void UpdateHeadsetPose(Vector3 pos, Quaternion rot) {

		if (ARCameraManager != null) {

			ARCameraManager.updateHeadsetPosition (pos);
			ARCameraManager.updateHeadsetRotation (rot);

			headsetPos = pos;
			headsetRot = rot;

		} else {

			Debug.LogError ("Attempting to update tracker pose but ARCameraManager is null.");

		}
	}
	

	public static string getUserIP() {
		return IPinputField.text;
	}
}