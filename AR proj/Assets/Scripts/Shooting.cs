using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

	public GameObject damageBeamObject;
	public GameObject healingBeamObject;

	private Beam damageBeam;
	private Beam healingBeam;
	private bool paused;

	// Use this for initialization
	void Start () {
		damageBeam = damageBeamObject.GetComponent<Beam>();
		healingBeam = healingBeamObject.GetComponent<Beam>();
	}

	void Update () {
		
	}
	public void Pause() {
		damageBeam.Pause();
		healingBeam.Pause();
		paused = true;
	}
	public void Resume() {

		paused = false;
	}

	public void startDamage() {
		if (!damageBeam.isEmitting() && !paused ) {
			damageBeam.StartEmitting();
		}
	}
	public void startHeal() {
		if (!healingBeam.isEmitting() && !paused) {
			healingBeam.StartEmitting();
		}
	}

	public void StopDamage() {
		damageBeam.StopEmitting();
	}

	public void StopHeal() {
		healingBeam.StopEmitting();
	}

}

