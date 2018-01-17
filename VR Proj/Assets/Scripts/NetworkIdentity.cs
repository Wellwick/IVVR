using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * IMPORTANT CLASS
 * -----------------
 * This script must be attached to any object that wants to be synchronised over a network.
 * It uses a static counter to count the number of objects in the world and then assign a value based on that.
 * It also keeps track of whether ab object is expecting to be updated on the other end of the network and
 * the previous transform.
 *
 */

public class NetworkIdentity : MonoBehaviour {

	public static int objectCount;
	private int objectId;
	private bool updateWaiting = false;
	private Transform previousTransform;


	// Use this for initialization
	void Start () {
		objectId = objectCount;
		objectCount++;
		previousTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(!previousTransform.Equals(this.transform) & !updateWaiting){
			GameObject.FindObjectOfType<NetworkManager>().messageQueue.Enqueue(gameObject); //add object to queue to be sent 
			updateWaiting = true;

		}
		previousTransform = this.transform;
	}

	public int getObjectId(){
		return objectId;
	}

	public void setUpdateWaiting(){
		updateWaiting = false;
	}
}
