using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class MoveTo : MonoBehaviour {

	public Transform goal;
	NavMeshAgent agent;
	private float damageTimer;
	public GameObject healthSprite;

	void Start () {
		agent = GetComponent<NavMeshAgent>();
		agent.destination = goal.position; 
		damageTimer = 0.0f;
	}

	void Update() {
		agent.destination = goal.position;
		GetComponent<Transform>().LookAt(goal);


		if (damageTimer > 0.0f) damageTimer -= Time.deltaTime;

		float dist = Vector3.Distance(transform.position, goal.position);
		// Example distance is 2 units
		// Damage the enemy if the damage timer is back below 0
		if (dist < 2.0f && damageTimer <= 0.0f) {
			PlayerHealth ph = goal.gameObject.GetComponent<PlayerHealth>();
			ph.currentHealth -= 1;
			// Spawn the sprite and have it come to enemy
			GameObject sprite = GameObject.Instantiate(healthSprite, goal.position, goal.rotation);
			sprite.GetComponent<SpriteRenderer>().color = EnemyManager.calculateSpriteColor(ph);
			damageTimer = 1.0f;
		}
	}
	
}
