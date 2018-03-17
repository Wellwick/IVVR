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

		showingOptions = !showingOptions;
		optionsPanelObject.SetActive (showingOptions);

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
	}

	void OnMouseDown()
    {
        
    }

	void OnMouseUp()
    {
        
    }

}
