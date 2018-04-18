using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyeball : MonoBehaviour {

	public GameObject healBeam;
	public GameObject damageBeam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Heal() {
		healBeam.GetComponent<Beam>().StartEmitting();
		damageBeam.GetComponent<Beam>().StopEmitting();
	}

	public void Damage() {
		damageBeam.GetComponent<Beam>().StartEmitting();
		healBeam.GetComponent<Beam>().StopEmitting();
	}

	public void Beamless() {
		healBeam.GetComponent<Beam>().StopEmitting();
		damageBeam.GetComponent<Beam>().StopEmitting();
	}
}



