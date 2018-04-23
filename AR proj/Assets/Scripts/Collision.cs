using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

	private ParticleSystem particle;
    public List<ParticleCollisionEvent> collisionEvents;
    public bool damagingBeam; // if set to 1: variable 'other' in OnParticleCollision is only going to be of type Enemy

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
        //Rigidbody rb = other.GetComponent<Rigidbody>();
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

        if (damagingBeam) {
            other.GetComponentInParent<EnemyHealth>().Damage(i);
            //Debug.Log("damaging enemy by " + i);
        }

        if (!damagingBeam) {
            other.GetComponentInParent<PlayerHealth>().Heal(i);
            //Debug.Log("healing player by " + i);
        }
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
