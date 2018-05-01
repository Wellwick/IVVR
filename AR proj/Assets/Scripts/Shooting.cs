using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

	public GameObject damageBeamObject;
	public GameObject healingBeamObject;

	private Beam damageBeam;
	private Beam healingBeam;
	private GameManager gameManager;

	// Use this for initialization
	void Start () {
		damageBeam = damageBeamObject.GetComponent<Beam>();
		healingBeam = healingBeamObject.GetComponent<Beam>();
		gameManager = FindObjectOfType<GameManager>();
	}

	void Update () {
		
	}

	public void startDamage() {
		if (!damageBeam.isEmitting() && gameManager.GetGameState() == GameState.Active) {
			damageBeam.StartEmitting();
		}
	}
	public void startHeal() {
		if (!healingBeam.isEmitting() && gameManager.GetGameState() == GameState.Active) {
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

