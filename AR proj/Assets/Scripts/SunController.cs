using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController : MonoBehaviour {

    public GameObject originObject; //rotate around this point in the world
    public float dayLength = 300.0f; // how long it takes to rotate 360
    public float startTime = 0.0f;
    public Vector3 planeNormal;
    //Up vector of plane in which the sun rotates
    // This is also the axis of rotation

    //will move as well as changing direction (dummy object for calculations)
    // not needed because sunObject will be set to simply parent obejct
    //public GameObject sunObject;


    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        float timePassed = Time.deltaTime;
        float angle = 360 * (timePassed / dayLength);

        transform.RotateAround(originObject.transform.position, planeNormal, angle);
        transform.LookAt(originObject.transform.position);

	}

    //time should be between 0 and 1
    private void SetTime(float time)
    {
        float angle = 360 * time;

        //find arbitrary point on plane by restricting y
        //Vector3 forward = 
    }
}
