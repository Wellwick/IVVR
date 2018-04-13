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


	// Use this for initialization
	void Start () {
		//Set beams to converge at a point <range> distance in front of the camera.
		Vector3 target = gameObject.transform.parent.position + (gameObject.transform.parent.forward * range);
		gameObject.transform.LookAt(target);

		particleSys = gameObject.GetComponent<ParticleSystem>();
		StopEmitting();
	}

	// Update is called once per frame
	void Update () {
		
		duration = duration + Time.deltaTime;
		gameObject.transform.Rotate(0, 0, rotationSpeed * duration * 2);

	}


	public void StartEmitting() {
		particleSys.Play();
		//Debug.Log("STarting Emmission");
	}

	public void StopEmitting() {
		particleSys.Stop(false, ParticleSystemStopBehavior.StopEmitting);
		//Debug.Log("Stopping Emmission");
	}
}
