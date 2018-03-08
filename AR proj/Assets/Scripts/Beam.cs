using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour {

	public GameObject beam;

	public enum beamType : byte {
		None = 0,
		Damage = 1,
		Heal = 2

	}

	public static beamType type;
	public float damageVal;
	public float rotationSpeed;
	private float duration;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		duration = duration - Time.deltaTime;

		if (duration <= 0.0f) {
			beam.GetComponent<ParticleSystem>().Stop();
		} else {
			
			beam.transform.Rotate(0, 0, rotationSpeed * duration * 2);
		}
	}

	public void Shoot() {

		duration = 1.0f;
		beam.GetComponent<ParticleSystem>().Play();

	}
}
