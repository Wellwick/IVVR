using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

	public GameObject beamPrefab;
	private GameObject beam;

	private Camera m_camera;
	private Vector3 rayOffset;



	// Use this for initialization
	void Start () {
		rayOffset = new Vector3 (0.0f, -0.1f, 0.0f);
		m_camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public GameObject raycast(Transform parent) {


		RaycastHit hit; //Store result of raycast here
		GameObject result = null; //The GAmeObject hit by the ray

		Vector3 origin = parent.position;
		Vector3 direction = parent.forward;
		//Vector3 origin = ARManager.getUnityCameraPosition(); 
		//Vector3 direction = ARManager.getUnityCameraRotation(); 


		if (Physics.Raycast(origin, direction, out hit)) {
			result = hit.transform.gameObject;
			Debug.Log(result.name);
		}

		return result;
	}

	public void damage() {

		Transform t = m_camera.transform;

		Vector3 origin = t.position + rayOffset; //Offset the ray so that it does not come out from the camera, but rather from below it

		Vector3 direction = t.forward;


		GameObject collision;

		Debug.Log ("Shooting damage from " );
		if ((collision = raycast (t)) != null) {
			Debug.Log (t.position.x + " " + t.position.y + " " + t.position.z);
			Vector3 end = collision.transform.position;

			float length = Vector3.Distance (end, origin);

			//lock beam onto enemy origin
			beam = Instantiate (beamPrefab, origin + 0.5f * (end - origin), Quaternion.Euler(end - origin));

			//beam = Instantiate (beamPrefab, origin, direction);

			beam.transform.localScale = new Vector3 (0.01f, 0.01f, length);

		}
	}

	public void heal() {
		
		Transform t = m_camera.transform;
		t.position = t.position + rayOffset; //Offset the ray so that it does not come out from the camera, but rather from below it

		Instantiate (beamPrefab,t);
		Debug.Log ("Shooting healing...");
		raycast (t);

	}
}
