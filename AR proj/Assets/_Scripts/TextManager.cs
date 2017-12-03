using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TextManager : MonoBehaviour {

	public GameObject positionTextObject;
	public GameObject networkTextObject;

	private UnityARCameraManager ARManager;
	private Text networkText;
	private Text positionText;


	// Use this for initialization
	void Start () {
		positionText = positionTextObject.GetComponent<Text>();
		positionText.text = "Updating position text...";
		networkText = networkTextObject.GetComponent<Text> ();
		networkText.text = "Updating network text...";

		ARManager = GameObject.FindObjectOfType<UnityARCameraManager>();
	}
	
	// Update is called once per frame
	void Update () {
		positionText.text = "{" + Math.Round(ARManager.getPosition().x, 2) + ", " +
			Math.Round(ARManager.getPosition().y, 2) + ", " +
			Math.Round(ARManager.getPosition().z, 2) + "}";
	}

	public void changeNetworkString(String networkString) {
		networkText.text = networkString;
	}
}
