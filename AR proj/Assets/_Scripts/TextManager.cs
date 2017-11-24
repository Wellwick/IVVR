using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TextManager : MonoBehaviour {

	public GameObject textObject;

	private UnityARCameraManager ARManager;
	private Text txt;


	// Use this for initialization
	void Start () {
		txt = textObject.GetComponent<Text>();
		txt.text = "Chris smells";
		ARManager = GameObject.FindObjectOfType<UnityARCameraManager>();
	}
	
	// Update is called once per frame
	void Update () {
		txt.text = "{" + Math.Round(ARManager.getPosition().x, 2) + ", " +
			Math.Round(ARManager.getPosition().y, 2) + ", " +
			Math.Round(ARManager.getPosition().z, 2) + "}";
	}
}
