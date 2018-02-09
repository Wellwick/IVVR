using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour {

	public GameObject beam;

	private float duration;
	private GameObject target;
	private GameObject source;
	private Vector3 end;
	private Vector3 offset;

	// Use this for initialization
	void Start () {

		target = null;
		source = null;
	}
	
	// Update is called once per frame
	void Update () {


		duration = duration - Time.deltaTime;
		if (duration <= 0.0f) {
			beam.SetActive (false);
		} else {

			Vector3 end;
			Vector3 origin = source.transform.position + offset;

			if (target != null) {
				end = target.transform.position;
			} else {
				end = origin + (source.transform.forward * 10.0f);
			}

			float length = Vector3.Distance (end, origin);
			beam.transform.position = Vector3.Lerp (origin, end, 0.5f);
			beam.transform.localScale = new Vector3 (0.01f, 0.01f, length);
			beam.transform.LookAt (end);
		}
	}

	public void Shoot(GameObject source, GameObject target, Vector3 offset) {

		this.source = source;
		this.target = target;
		this.offset = offset;

		duration = 1.0f;
		beam.SetActive (true);

	}
}
