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
	public ParticleSystem particleSys;
	public static beamType type;
	public float damageVal;
	public float rotationSpeed;
	public float range;

	private float duration;


	// Use this for initialization
	void Start () {
		//Set beams to converge at a point <range> distance in front of the camera.
		Vector3 target = beam.transform.parent.position + (beam.transform.parent.forward * range);
		beam.transform.LookAt(target);

		particleSys = beam.GetComponent<ParticleSystem>();
		StopEmitting();
	}

	// Update is called once per frame
	void Update () {

		beam.transform.Rotate(0, 0, rotationSpeed * duration * 2);

	}


	public void StartEmitting() {
		particleSys.Play();
		Debug.Log("STarting Emmission");
	}

	public void StopEmitting() {
		particleSys.Stop(false, ParticleSystemStopBehavior.StopEmitting);
		Debug.Log("Stopping Emmission");
	}
}
