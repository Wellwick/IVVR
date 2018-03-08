using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

	public ParticleSystem particle;
    public List<ParticleCollisionEvent> collisionEvents;

	void Start() {
        particle = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
	}	

	void OnTriggerEnter(Collider other) {
		Debug.Log("onTriggerEnter");
        //Destroy(other.gameObject);
    }

    void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = particle.GetCollisionEvents(other, collisionEvents);
		Debug.Log("onparticlecollision");
        Rigidbody rb = other.GetComponent<Rigidbody>();
        int i = 0;

        while (i < numCollisionEvents)
        {
            /*if (rb)
            {
                Vector3 pos = collisionEvents[i].intersection;
                Vector3 force = collisionEvents[i].velocity * 10;
                rb.AddForce(force);
            }*/
            i++;
        }
        if (i > 0) {
            Debug.Log("Damaging enemy by " + i);
            //Damage(i);
        }
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
