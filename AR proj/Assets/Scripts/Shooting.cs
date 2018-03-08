using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

	//public GameObject beamPrefab;
	public GameObject beamDamage;
	public GameObject beamHealing;

	private Camera m_camera;
	private Vector3 rayOffset;



	// Use this for initialization
	void Start () {
		rayOffset = new Vector3 (0.0f, -0.2f, 0.0f);
		m_camera = Camera.main;

	}

	void Update () {
		
	}

	public void damage() {

		beamDamage.GetComponent<Beam>().Shoot();

	}

	public void heal() {
		
		beamHealing.GetComponent<Beam>().Shoot();

	}
}
