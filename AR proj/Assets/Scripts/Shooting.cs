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
		if (!beamHealing.GetComponent<Beam>().isEmitting()) {
			beamDamage.GetComponent<Beam>().StartEmitting();
		}

	}

	public void StartHeal() {
		
		if (!beamDamage.GetComponent<Beam>().isEmitting()) {
			beamHealing.GetComponent<Beam>().StartEmitting();
		}

	}
	public void StopDamage() {

		beamDamage.GetComponent<Beam>().StopEmitting();

	}

	public void StopHeal() {
		
		beamHealing.GetComponent<Beam>().StopEmitting();

	}
}
