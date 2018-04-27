using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

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

	public static int objectCount = 0;
	private int objectId;
	private bool watched = false;
	private Vector3 previousPos;
	private Quaternion previousRot;
	public NetworkManager networkManager;


	//called when a new object with this script acttached is spawned
	void Awake () {
		if(networkManager.isHost){

			// set the localId to the current value of the counter and then increment it 
			objectId = objectCount;
			Interlocked.Increment(ref objectCount);

			//keep track of the last known position and rotation
			previousPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
			previousRot = new Quaternion(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w);

			//add object to the dictionary of existing networked objects
			networkManager.networkedObjects.Add(objectId, gameObject);

			//if there is a connection then spawn the new object
			if(networkManager.isConnection()){
				networkManager.SendSpawn(gameObject);
			}
		} else {

			//if the current application is not the host then do not set an id and only add it to the dictionary
			networkManager.networkedObjects.Add(objectId, gameObject);
		}

	}

	void Start(){
	}
	// Update is called once per frame
	void Update () {

		// if the currect application is the host
		if(networkManager.isHost){

			// if the position or rotation has changed between frames then add object to the watchlist
			// else, if the object was currently being watched, remove the object from the watch list
			if((!previousPos.Equals(this.transform.position) || !previousRot.Equals(this.transform.rotation))){
				if(!networkManager.watchList.ContainsKey(objectId)){
					//Debug.Log("Adding to the watchlist");
					networkManager.watchList.Add(objectId, gameObject);
					watched = true;
				}
			}else{
				if(watched){
					networkManager.watchList.Remove(objectId);
					watched = false;
				}
		}

		//update last tracked location and rotation
		previousPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
		previousRot = new Quaternion(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w);
		}

	}

	//If the object is destroyed and this is the host, then send a remove command to all clients and remove traces of object from dictionaries
	void OnDestroy(){
		if(networkManager.isHost){
			networkManager.SendRemove(objectId);
			networkManager.networkedObjects.Remove(objectId);
			if(watched){
				networkManager.watchList.Remove(objectId);
			}
		}

	}

	public int getObjectId(){
		return objectId;
	}

	public void setObjectId(int id){
		objectId = id;
	}

}
