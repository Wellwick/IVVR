using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	public Prefabs prebabs;



	public GameObject SpawnObject(int prefabId, NetworkManager.SerializeableTransform st){
		Vector3 position = new Vector3(st.posX, st.posY, st.posZ);
		Debug.Log(position);
		Debug.Log("The Prefab Id is: " + prefabId + " otherwise known as " + ((Prefabs.PID)prefabId).ToString());
		return Instantiate(prebabs.prefabs[prefabId], position, new Quaternion(st.rotX, st.rotY, st.rotZ, st.rotW)) as GameObject;
	}
}
