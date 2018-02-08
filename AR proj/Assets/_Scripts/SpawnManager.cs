using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	public Prefabs prefabs;
	public GameObject enemyPrefab;


	/*public GameObject SpawnObject(int prefabId, NetworkManager.SerializeableTransform st){
		Vector3 position = new Vector3(st.posX, st.posY, st.posZ);
		Quaternion rotation = new Quaternion(st.rotX, st.rotY, st.rotZ, st.rotW);
		Debug.Log(position);
		Debug.Log("The Prefab Id is: " + prefabId + " otherwise known as " + ((Prefabs.PID)prefabId).ToString());
		return Instantiate(prebabs.prefabs[prefabId], position, rotation) as GameObject;
	}*/

	public GameObject SpawnObject(int prefabId, Vector3 pos, Quaternion rot, Vector3 vel) {
		Debug.Log(pos);
		Debug.Log("The Prefab Id is: " + prefabId + " otherwise known as " + ((Prefabs.PID)prefabId).ToString());
		//need to set rigidbody vel
		return Instantiate(prefabs.prefabs[prefabId], pos, rot) as GameObject;
	}


	// Use this for initialization
	void Start () {
	}

	public void SpawnEnemy () {
		
		GameObject enemy = Instantiate(enemyPrefab, new Vector3(0,2,1), Quaternion.identity) as GameObject;

		//return enemy;
	}
}

