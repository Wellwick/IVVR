using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class MoveTo : MonoBehaviour {

	public Transform goal;
	NavMeshAgent agent;

	void Start () {
		agent = GetComponent<NavMeshAgent>();
		agent.destination = goal.position; 
	}

	void Update() {
		agent.destination = goal.position;
		GetComponent<Transform>().LookAt(goal);
	}
	
}
