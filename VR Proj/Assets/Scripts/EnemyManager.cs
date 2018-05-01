using UnityEngine;
using UnityEngine.AI;
//using UnityEngine.XR;

public class EnemyManager : MonoBehaviour
{
	//public PlayerHealth playerHealth;     // Reference to the player's heatlh
    [Header("VR Scene")]
    public GameObject camera;

    [Header("Enemy Settings")]
    public GameObject enemyPrefab;                // The enemy prefab to be spawned
    public GameObject healthSpritePrefab;
    public int enemyStartingHealth = 1000;
    
    [Header("Spawn Settings")]
    public GameObject parentObject;         // Enemies will spawn as children of this gameobject
    public float minSpawnDistance = 30.0f;
    public float maxSpawnDistance = 40.0f; 
	public float spawnInterval = 10f;           // How long between each spawn
    public int maxEnemies = 10;
    
    //Kinda wanna make this private, add getter method, calculate how many enemies exist in scene manually
    public int enemyCount;


    private bool spawning = false;

	void Start () {
		enemyCount = FindObjectsOfType<EnemyHealth>().Length;
	}


    public void StartSpawning()
    {
        // Call the Spawn function after a delay of the spawnInterval // or dont
        // and then continue to call after the same amount of time.
        CancelInvoke("Spawn");
        InvokeRepeating("Spawn", 0, spawnInterval);
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

		Vector3 loc = GetRandomSpawnLocation();

		loc = calculateHitLocation (loc, 2.5f);
	
		GameObject go = Instantiate (enemyPrefab, loc, rot, parentObject.transform);
		NavMeshAgent agent = go.GetComponent<NavMeshAgent> ();
		go.GetComponent<MoveTo>().healthSprite = healthSpritePrefab;
		go.GetComponent<MoveTo>().goal = camera.transform;
		agent.Warp (loc);
		enemyCount++;
	}

	void Update ()
	{
		// If an enemy is in range of the player then cause damage
		// This is done in the MoveTo script
	}

    // Old method of calculating new spawns. Use new method
	/*
     * Vector3 calculateSpawn() {
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
	}*/

    /*
     * Gets circumferrence of VR scene, spawns a random location between
     * 
     *
     */
    private Vector3 GetRandomSpawnLocation()
    {
        // Get random angle between 0 and 360
        float angle = Random.Range(0, 360.0f);

        // Get random distance between minSpawnDist and maxSpawnDist
        float dist = Random.Range(minSpawnDistance, maxSpawnDistance);

        return ((Quaternion.Euler(0.0f, angle, 0.0f) * Vector3.forward) * dist) + parentObject.transform.position;
        
    }

	Vector3 calculateHitLocation(Vector3 loc, float range) {
		NavMeshHit hit;
        if (NavMesh.SamplePosition(loc, out hit, range, NavMesh.AllAreas))
        {
            loc = hit.position;
        } 
        else
        {
            //Debug.Log(loc);
        }
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