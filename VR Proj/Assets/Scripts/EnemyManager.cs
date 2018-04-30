using UnityEngine;
using UnityEngine.AI;
//using UnityEngine.XR;

public class EnemyManager : MonoBehaviour
{
	//public PlayerHealth playerHealth;     // Reference to the player's heatlh
	public GameObject Enemy;                // The enemy prefab to be spawned
	public GameObject camera;
	public GameObject healthSprite;
    public GameObject parentObject;         // Enemies will spawn as children of this gameobject

	public float spawnInterval = 10f;           // How long between each spawn
    public int startingHealth = 1000;
    public int maxEnemies = 10;
    public int enemyCount;


    private bool spawning = false;

	void Start () {
		enemyCount = FindObjectsOfType<EnemyHealth>().Length;
	}

    public void StartSpawning()
    {
        // Call the Spawn function after a delay of the spawnInterval and then continue to call after the same amount of time.
        CancelInvoke("Spawn");
        InvokeRepeating("Spawn", spawnInterval, spawnInterval);
    }
    public void PauseSpawning()
    {

        // This may not be the best solution, as it will reset the timer
        // This could be abused; pause the game just before enemies spawn, then unpause
        CancelInvoke("Spawn");
    }

    public bool IsSpawning()
    {
        return spawning;
    }

    void Spawn ()
	{
		// If the player has no health left...
		// if(playerHealth.currentHealth <= 0f) return; 

		if (enemyCount >= maxEnemies) return;	// Ensures not too many enemies are in the game // 

		// Calculate spawn location and necessary rotation  // 

		Quaternion rot = new Quaternion(0f, 0f, 0f, 0f);

		Vector3 loc = calculateSpawn();

		loc = calculateHitLocation (loc, 2.5f);
	
		GameObject go = Instantiate (Enemy, loc, rot, parentObject.transform);
		NavMeshAgent agent = go.GetComponent<NavMeshAgent> ();
		go.GetComponent<MoveTo>().healthSprite = healthSprite;
		go.GetComponent<MoveTo>().goal = camera.transform;
		agent.Warp (loc);
		enemyCount++;
	}

	void Update ()
	{
		// If an enemy is in range of the player then cause damage
		// This is done in the MoveTo script
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
		if (NavMesh.SamplePosition (loc, out hit, range, NavMesh.AllAreas)) loc = hit.position;
		else Debug.Log (loc);
		return loc;
	}

	// Works out what colour the particle is that is leaving the player
	public static Color calculateSpriteColor(PlayerHealth ph) {
		float halfHealth = (float)ph.maxHealth/2.0f;
		if (ph.currentHealth > halfHealth) {
			// We want maximum green and red in a range
			float percentage = 1.0f - (float)(ph.currentHealth-halfHealth) / halfHealth;
			return new Color(percentage, 1.0f, 0.0f);
		} else {
			// Aiming for maximum red, green in range
			float percentage = (float)ph.currentHealth / halfHealth;
			return new Color(1.0f, percentage, 0.0f);
		}
	}

}


//Vector3 goalLoc = UnityEngine.XR.InputTracking.GetLocalPosition (XRNode.CenterEye);
//Quaternion goalRot = UnityEngine.XR.InputTracking.GetLocalRotation (XRNode.CenterEye);