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
	private bool watched = false;
	private Vector3 previousPos;
	private Quaternion previousRot;
	private NetworkManager networkManager;


	// Use this for initialization
	void Awake () {
		networkManager = GameObject.FindObjectOfType<NetworkManager>();
		objectId = objectCount;
		objectCount++;
		previousPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
		previousRot = new Quaternion(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w);
		Debug.Log("This objects id is " + objectId);
	}
	
	// Update is called once per frame
	void Update () {
		if((!previousPos.Equals(this.transform.position) || !previousRot.Equals(this.transform.rotation))){
			if(!networkManager.watchList.ContainsKey(objectId)){
				Debug.Log("Adding to the watchlist");
				networkManager.watchList.Add(objectId, gameObject);
				watched = true;
			}

		}else{
			if(watched){
				networkManager.watchList.Remove(objectId);
				watched = false; 
			}
		}
		previousPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
		previousRot = new Quaternion(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w);
	}

	public int getObjectId(){
		return objectId;
	}
}
