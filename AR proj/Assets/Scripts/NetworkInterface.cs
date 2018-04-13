using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkInterface : MonoBehaviour {

	public GameObject HealBeamObject;
	public GameObject DamageBeamObject;

	private static UnityARCameraManager ARCameraManager;
	private static TextManager textManager;
	private static Beam HealBeam;
	private static Beam DamageBeam;

	void Start() {

		ARCameraManager = GameObject.FindObjectOfType<UnityARCameraManager>();
		textManager = GameObject.FindObjectOfType<TextManager> ();
		//Debug.Log ("Starting Network Interface... <TextManager found>:" + (textManager != null) + " <ARCameraManager found>:" + (ARCameraManager != null));
		HealBeam = HealBeamObject.GetComponent<Beam>();
		DamageBeam = DamageBeamObject.GetComponent<Beam>();
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

	public static void UpdateNetworkStatus(string status) {

		if (textManager != null) {

			textManager.changeNetworkString (status);
			textManager.changeLatencyString (status);

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