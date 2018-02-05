using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : MonoBehaviour {

	private SteamVR_TrackedObject trackedObj;
	public GameObject grapplePrefab;
	private GameObject grapple;
	private Transform grappleTransform;

	public LayerMask grappleMask;
	private bool shouldPull;

	private GameObject pullObject;

	public float speed = 1.0f;
	
	// Use this for initialization
	void Start () {
		grapple = Instantiate(grapplePrefab);
		grappleTransform = grapple.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad)) {
			RaycastHit hit;


			if (Physics.Raycast(trackedObj.transform.position, transform.forward, out hit, 100, 
					grappleMask)) {
				ShowGrapple(hit);
				shouldPull = true;
				pullObject = hit.transform.gameObject;
			}
		} else {
			grapple.SetActive(false);
			shouldPull = false;
		}
		
		if (Controller.GetHairTriggerDown() && shouldPull) {
			float step = speed * Time.deltaTime;
			pullObject.transform.position = Vector3.MoveTowards(pullObject.transform.position, 
												transform.position, step);
		}
	}

	private SteamVR_Controller.Device Controller {
		get { return SteamVR_Controller.Input((int)trackedObj.index); }
	}

	void Awake() {
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}

	private void ShowGrapple(RaycastHit hit) {
		grapple.SetActive(true);

		grappleTransform.position = Vector3.Lerp(trackedObj.transform.position, hit.point, .5f);
		grappleTransform.LookAt(hit.point);
		grappleTransform.localScale = new Vector3(grappleTransform.localScale.x, grappleTransform.localScale.y,
			hit.distance);

	}
}
