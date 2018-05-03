using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class MoveTo : MonoBehaviour {

	public Transform goal;
	NavMeshAgent agent;
	private float damageTimer;
	public GameObject healthSprite;

    private GameManager gameManager;

	void Start () {
		agent = GetComponent<NavMeshAgent>();
		agent.destination = goal.position; 
		damageTimer = 0.0f;

        gameManager = FindObjectOfType<GameManager>();
	}

	void Update() {

        if (damageTimer > 0.0f) damageTimer -= Time.deltaTime;
        Vector3 currentPos = new Vector3(transform.position.x, 0.0f, transform.position.z);
        Vector3 goalPos = new Vector3(goal.position.x, 0.0f, goal.position.z);
        float dist = Vector3.Distance(currentPos, goalPos);

        if (gameManager.GetGameState() == GameState.Paused) {
            agent.isStopped = true;
            return;
        } else if (dist > 1.6f) {
            agent.isStopped = false;
            agent.destination = goal.position;
        }

        GetComponent<Transform>().LookAt(goal);

        // Example distance is 2 units
        // Damage the enemy if the damage timer is back below 0
        if (dist < 2.0f) {
            agent.isStopped = true;
            if (damageTimer <= 0.0f) {
                PlayerHealth ph = goal.gameObject.GetComponent<PlayerHealth>();
                ph.currentHealth -= 60;
                // Spawn the sprite and have it come to enemy
                Vector3 belowCam = new Vector3(goal.position.x, goal.position.y, goal.position.z);
                GameObject sprite = GameObject.Instantiate(healthSprite, goal.position, goal.rotation);
                sprite.transform.position += new Vector3(0.0f, -0.4f, 0.0f);
                sprite.GetComponent<HealthParticle>().camera = goal;
                sprite.GetComponent<HealthParticle>().target = transform;
                sprite.GetComponent<SpriteRenderer>().color = EnemyManager.calculateSpriteColor(ph);
                damageTimer = 1.0f;
            }
        }
	}
	
}
