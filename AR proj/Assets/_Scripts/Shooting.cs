using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {



	private UnityARCameraManager ARManager;
	private Camera m_camera;
	private Vector3 rayOffset;

	// Use this for initialization
	void Start () {
		ARManager = GameObject.FindObjectOfType<UnityARCameraManager>();
		m_camera = Camera.main;
		rayOffset = new Vector3 (0.0f, -0.01f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public GameObject raycast() {


		RaycastHit hit; //Store result of raycast here
		GameObject result = null; //The GAmeObject hit by the ray
		Vector3 origin = m_camera.transform.position + rayOffset; //The origin of the ray
		Vector3 direction = m_camera.transform.forward;//direction of ray

		//Vector3 origin = ARManager.getUnityCameraPosition(); 
		//Vector3 direction = ARManager.getUnityCameraRotation(); 


		if (Physics.Raycast(origin, direction, out hit)) {
			result = hit.transform.gameObject;
			Debug.Log(result.name);
		}

		return result;
	}

	public void damage() {


		raycast ();
	}

	public void heal() {

		raycast ();
	}
}
