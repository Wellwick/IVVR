using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beam_damage : MonoBehaviour {

	float duration = 5.0f;

	GameObject target;
	//GameObject source;



	// Use this for initialization
	void Start () {


	}




	// Update is called once per frame
	void Update () {
		

		duration = duration - Time.deltaTime;

		if (duration <= 0) {
			Destroy (this);
		}
	}


	public void setTarget(GameObject target) {
		this.target = target;



	}
}
