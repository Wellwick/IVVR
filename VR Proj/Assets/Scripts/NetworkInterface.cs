using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkInterface : MonoBehaviour {

	//private UnityARCameraManager ARCameraManager;

	void Start() {
		//ARCameraManager = GameObject.FindObjectOfType<UnityARCameraManager>();
	}

	void Update() {

	}

	public static Transform GetCameraTransform() {
		/*if (ARCameraManager != null) {
			return ARCameraManager.GetUnityCameraTransform();

		} else {

			Debug.LogError ("Attempting to retrieve Unity camera transform but ARCameraManager is null.");

			return null;
		}*/
		return null;
	}
	 
	public static void UpdateTrackerPose(Vector3 pos, Quaternion rot) {

		//ARCameraManager.updateTrackerPosition (pos);
		//ARCameraManager.updateTrackerRotation (rot);

	}
}
