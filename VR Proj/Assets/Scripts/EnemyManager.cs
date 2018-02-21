using UnityEngine;
using UnityEngine.AI;
//using UnityEngine.XR;

public class EnemyManager : MonoBehaviour
{
	//public PlayerHealth playerHealth;     // Reference to the player's heatlh
	public GameObject Enemy;                // The enemy prefab to be spawned
	private float spawnTime = 50f;           // How long between each spawn
	public int enemyCount;

	void Start () {
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
		enemyCount = 0;
	}

	void Spawn ()
	{
		// If the player has no health left...
		// if(playerHealth.currentHealth <= 0f) return; 

		if (enemyCount >= 10) return;	// Ensures not too many enemies are in the game // 

		// Calculate spawn location and necessary rotation  // 

		Quaternion rot = new Quaternion(0f, 0f, 0f, 0f);

		Vector3 loc = calculateSpawn();

		loc = calculateHitLocation (loc, 2.5f);
	
		GameObject go = (GameObject)Instantiate (Enemy, loc, rot);
		NavMeshAgent agent = go.GetComponent<NavMeshAgent> ();
		agent.Warp (loc);
		enemyCount++;
	}

	Vector3 calculateSpawn() {
		int section = Random.Range(0,2);
		float xLoc = 238.0f;
		float yLoc = 110.0f;
		float zLoc = Random.Range(275.0f, 300.0f);

		//Debug.Log (section);

		switch (section) {
		case 0:
			xLoc = Random.Range (254.0f, 264.0f);
			break;
		case 1:
			xLoc = Random.Range (210.0f, 220.0f);
			break;
		}
		return new Vector3(xLoc, yLoc, zLoc);
	}

	Vector3 calculateHitLocation(Vector3 loc, float range) {
		NavMeshHit hit;
		loc = new Vector3 (0f, 0f, 0f);
		if (NavMesh.SamplePosition (loc, out hit, range, NavMesh.AllAreas)) loc = hit.position;
		else Debug.Log (loc);
		return loc;
	}

}


//Vector3 goalLoc = UnityEngine.XR.InputTracking.GetLocalPosition (XRNode.CenterEye);
//Quaternion goalRot = UnityEngine.XR.InputTracking.GetLocalRotation (XRNode.CenterEye);