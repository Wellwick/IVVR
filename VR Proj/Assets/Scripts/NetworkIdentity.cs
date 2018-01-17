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
	private Vector3 previousPos;
	private Quaternion previousRot;


	// Use this for initialization
	void Awake () {
		objectId = objectCount;
		objectCount++;
		previousPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
		previousRot = new Quaternion(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w);
		Debug.Log("This objects id is " + objectId);
	}
	
	// Update is called once per frame
	void Update () {
		if((!previousPos.Equals(this.transform.position) || !previousRot.Equals(this.transform.rotation)) & !updateWaiting){
			Debug.Log("Adding to the queue");
			GameObject.FindObjectOfType<NetworkManager>().messageQueue.Enqueue(gameObject); //add object to queue to be sent 
			updateWaiting = true;

		}
		previousPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
		previousRot = new Quaternion(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w);
	}

	public int getObjectId(){
		return objectId;
	}

	public void setUpdateWaiting(){
		updateWaiting = false;
	}
}
