using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARClient : MonoBehaviour {

	public GameObject healBeam;
	public GameObject damageBeam;
    public Beam.beamType fireType;

	// Use this for initialization
	void Start () {
        fireType = Beam.beamType.None;
	}

	void Update() {
		Heal();
	}
	
	public void Heal() {
		healBeam.GetComponent<Beam>().StartEmitting();
		damageBeam.GetComponent<Beam>().StopEmitting();
        fireType = Beam.beamType.Heal;
	}

	public void Damage() {
		damageBeam.GetComponent<Beam>().StartEmitting();
		healBeam.GetComponent<Beam>().StopEmitting();
        fireType = Beam.beamType.Damage;
	}

	public void Beamless() {
		healBeam.GetComponent<Beam>().StopEmitting();
		damageBeam.GetComponent<Beam>().StopEmitting();
        fireType = Beam.beamType.None;
	}
}
