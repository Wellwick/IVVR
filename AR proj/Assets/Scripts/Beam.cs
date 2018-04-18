using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour {


	public enum beamType : byte {
		None = 0,
		Damage = 1,
		Heal = 2

	}
	private ParticleSystem particleSys;

	public static beamType type;
	public float damageVal;
	public float rotationSpeed;
	public float range;

	private float duration;
	private bool emitting;


	// Use this for initialization
	void Start () {
		//Set beams to converge at a point <range> distance in front of the camera.
		Vector3 target = gameObject.transform.parent.position + (gameObject.transform.parent.forward * range);
		gameObject.transform.LookAt(target);

		particleSys = gameObject.GetComponent<ParticleSystem>();
		Debug.Log("Setting up new beam... Particle system: " + particleSys);
		StopEmitting();
	}

	// Update is called once per frame
	void Update () {

		duration = duration + Time.deltaTime;
		gameObject.transform.Rotate(0, 0, rotationSpeed * duration * 2);

	}


	public void StartEmitting() {
		//Debug.Log("STarting Emmission");
		particleSys = gameObject.GetComponent<ParticleSystem>();
		particleSys.Play();
		emitting = true;
	}

	public void StopEmitting() {
		//Debug.Log("Stopping Emmission");
		particleSys = gameObject.GetComponent<ParticleSystem>();
		particleSys.Stop(false, ParticleSystemStopBehavior.StopEmitting);
		emitting = false;
		//Debug.Log(System.Environment.StackTrace.ToString());
	}

	public bool isEmitting() {
		return emitting;
	}
}
