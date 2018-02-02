using UnityEngine;
using UnityEngine.AI;
//using UnityEngine.XR;

public class EnemyManager : MonoBehaviour
{
	//public PlayerHealth playerHealth;     // Reference to the player's heatlh
	public GameObject Enemy;                // The enemy prefab to be spawned
	public float spawnTime = 50f;           // How long between each spawn

	void Start () {
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}

	void Spawn ()
	{
		// If the player has no health left...
		// if(playerHealth.currentHealth <= 0f) return; 

		// Calculate spawn location and necessary rotation  // 

		Quaternion rot = new Quaternion(0f, 0f, 0f, 0f);

		// Spawning not too close
		int section = Random.Range(1,2);
		float xLoc = 238.0f;
		float zLoc = Random.Range(275.0f, 300.0f);
		Debug.Log (section);
		switch (section) {
		case 1:
			xLoc = Random.Range (254.0f, 264.0f);
			break;
		case 2:
			xLoc = Random.Range (210.0f, 220.0f);
			break;
		}

		Vector3 loc = new Vector3(xLoc, 110, zLoc);

		NavMeshHit hit;
		if (NavMesh.SamplePosition (loc, out hit, 5f, NavMesh.AllAreas)) {
			loc = hit.position;
			Debug.Log (loc);
			GameObject go = (GameObject)Instantiate (Enemy, loc, rot);
			NavMeshAgent agent = go.GetComponent<NavMeshAgent> ();
			agent.Warp (loc);
		} else {
			Debug.Log (loc);
		}
	}
}


//Vector3 goalLoc = UnityEngine.XR.InputTracking.GetLocalPosition (XRNode.CenterEye);
//Quaternion goalRot = UnityEngine.XR.InputTracking.GetLocalRotation (XRNode.CenterEye);