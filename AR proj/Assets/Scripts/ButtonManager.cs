using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {
	
	private bool showingDebug = false;
	private bool showingOptions = false;
	//public GameObject[] display;

	public GameObject debugPanelObject;
	public GameObject optionsPanelObject;
	public GameObject poseEstimationDropdownObject;
	public GameObject optionsButton;
	public GameObject HPindicatorObject;

	private UnityARCameraManager ARCameraManager;

	public Text selectedObjectText;

	//List<string> poseEstimationTechniques = new List<string>() { "ARKit","Attached Tracker","Calibration" };

	void Start() {
		debugPanelObject.SetActive (showingDebug);
		optionsPanelObject.SetActive (showingOptions);
		ARCameraManager = GameObject.FindObjectOfType<UnityARCameraManager>();
		//selectedObjectText = poseEstimationDropdownObject.GetComponentInChildren<Text>();
	}

	public void ToggleOptions() {
		Debug.Log("Toggle Options");

		showingOptions = !showingOptions;
		optionsPanelObject.SetActive (showingOptions);
		Vector3 rotationVector = transform.rotation.eulerAngles;
		
		if (showingOptions) {
			rotationVector.x = 0.0f;
			rotationVector.y = 0.0f;

		} else {
			rotationVector.x = 180.0f;
			rotationVector.y = 180.0f;
		}
		optionsButton.transform.rotation = Quaternion.Euler(rotationVector);

	}

	public void ToggleDebug(){
		/*
		foreach(GameObject uiElement in display){
			uiElement.active = true;
		}
		*/
		showingDebug = !showingDebug;
		debugPanelObject.SetActive (showingDebug);

	}

	public void poseEstimationDropdownIndexChange()
	{
		int index = poseEstimationDropdownObject.GetComponent<Dropdown> ().value;
		

		switch (index) {
		case 0:
			ARCameraManager.tracking = TrackingType.ARKit;
			break;
		case 1:
			ARCameraManager.tracking = TrackingType.TrackerRelay;
			break;
		case 2:
			ARCameraManager.tracking = TrackingType.TrackerCalibration;
			break;
		case 3:
			ARCameraManager.tracking = TrackingType.HeadsetCalibration;
			break;
		}
		Debug.Log("Changing pose estimation method: " + index+ " - " + ARCameraManager.tracking.ToString());
	}

	public void changeOcclusion() {
		Debug.Log("Changing occlusion to: " + !HPindicatorObject.activeSelf);
		HPindicatorObject.SetActive(!HPindicatorObject.activeSelf);
	}



}
