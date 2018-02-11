using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkInterface : MonoBehaviour {

	private static UnityARCameraManager ARCameraManager;

	void Start() {
		ARCameraManager = GameObject.FindObjectOfType<UnityARCameraManager>();
	}

	void Update() {

	}

	 
	public static void UpdateTrackerPose(Vector3 pos, Quaternion rot) {

		if (ARCameraManager != null) {
			
			ARCameraManager.updateTrackerPosition (pos);
			ARCameraManager.updateTrackerRotation (rot);

		} else {
			
			Debug.LogError ("Attempting to update tracker pose but ARCameraManager is null.");

		}
	}

}
