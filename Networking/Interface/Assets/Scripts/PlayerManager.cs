using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	NetworkManager network;

	// Use this for initialization
	void Start () {
		network = GameObject.FindObjectOfType<NetworkManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha0)){
			byte[] data = {0};
			network.SendByte(data);
		}else if(Input.GetKeyDown(KeyCode.Alpha1)){
			byte[] data = {1};
			network.SendByte(data);
		}
		
	}
}
