using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class MoveTo : MonoBehaviour {

	public Transform goal;

	void Start () {
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		agent.destination = goal.position; 
	}

	void Update() {
		
		GetComponent<Transform>().LookAt(goal);
	}
}
