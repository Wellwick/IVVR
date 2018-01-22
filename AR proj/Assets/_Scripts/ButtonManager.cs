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


	void Start() {
		debugPanelObject.SetActive (showingDebug);
		optionsPanelObject.SetActive (showingOptions);
	}

	public void ToggleOptions(){

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

}
