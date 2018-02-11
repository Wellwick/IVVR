using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkInterface : MonoBehaviour {

	private static UnityARCameraManager ARCameraManager;
	private static TextManager textManager;

	void Start() {
		ARCameraManager = GameObject.FindObjectOfType<UnityARCameraManager>();
		textManager = GameObject.FindObjectOfType<TextManager> ();
	}

	void Update() {

	}

	public static void UpdateNetworkStatus(string status) {
		textManager.changeNetworkString (status);
	}
	 
	public static void UpdateTrackerPose(Vector3 pos, Quaternion rot) {

		if (ARCameraManager != null) {
			
			ARCameraManager.updateTrackerPosition (pos);
			ARCameraManager.updateTrackerRotation (rot);

			textManager.updateTrackerPositionString (pos);
			textManager.updateTrackerRotationString (rot);

		} else {
			
			Debug.LogError ("Attempting to update tracker pose but ARCameraManager is null.");

		}
	}

}
