using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

	public GameObject beamDamage;
	public GameObject beamHealing;


	// Use this for initialization
	void Start () {

	}

	void Update () {
		
	}

	public void StartDamage() {

		beamDamage.GetComponent<Beam>().StartEmitting();

	}

	public void StartHeal() {
		
		beamHealing.GetComponent<Beam>().StartEmitting();

	}
	public void StopDamage() {

		beamDamage.GetComponent<Beam>().StopEmitting();

	}

	public void StopHeal() {
		
		beamHealing.GetComponent<Beam>().StopEmitting();

	}
}
