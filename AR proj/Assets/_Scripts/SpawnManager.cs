using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	public Prefabs prebabs;



	public GameObject SpawnObject(int prefabId, NetworkManager.SerializeableTransform st){
		return Instantiate(prebabs.prefabs[prefabId], new Vector3(st.posX, st.posY, st.posZ), new Quaternion(st.rotX, st.rotY, st.rotZ, st.rotW)) as GameObject;
	}
}
