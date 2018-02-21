using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

	//public GameObject beamPrefab;
	public GameObject beamDamage;
	public GameObject beamHealing;

	private Camera m_camera;
	private Vector3 rayOffset;



	// Use this for initialization
	void Start () {
		rayOffset = new Vector3 (0.0f, -0.1f, 0.0f);
		m_camera = Camera.main;

		//beamDamage.setSource (m_camera);
		//beamDamage.setOffset (rayOffset);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public GameObject raycast(Transform parent) {


		RaycastHit hit; //Store result of raycast here
		GameObject result = null; //The GAmeObject hit by the ray

		Vector3 origin = parent.position;
		Vector3 direction = parent.forward;
		//Vector3 origin = ARManager.getUnityCameraPosition(); 
		//Vector3 direction = ARManager.getUnityCameraRotation(); 


		if (Physics.Raycast(origin, direction, out hit)) {
			result = hit.transform.parent.gameObject;
			Debug.Log(result.name);
		}

		return result;
	}

	public void damage() {

		Transform t = m_camera.transform;

		GameObject target = null;

		target = raycast (t);

		if ((target = raycast (t)) != null) {
			Handheld.Vibrate ();

			EnemyHealth enemy = target.GetComponent<EnemyHealth>();
			if (enemy == null) {
				Debug.LogError("Parent gameObject of raycast result does not have <EnemyHealth>");
			} else {
				enemy.Damage(beamDamage.GetComponent<Beam>().damageVal);	
			}
			
			//ENEMY HIT???
		} 


		beamDamage.GetComponent<Beam>().Shoot(m_camera.gameObject, target, rayOffset);
	}

	public void heal() {
		
		Transform t = m_camera.transform;

		GameObject target = null;
	
		target = raycast (t);

		if ((target = raycast (t)) != null) {
			Handheld.Vibrate ();
			//ENEMY HIT???
		} 

		beamHealing.GetComponent<Beam>().Shoot(m_camera.gameObject, target, rayOffset);

	}
}
