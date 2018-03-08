using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class EnemyHealth : MonoBehaviour {

    // Use this for initialization
    public int maxHealth = 1000;
    public int currentHealth;
    //need to keep track of health since the last time that we updated the host
    public int transientHealthLoss = 0;
    //public Color color;
    private float alpha;
    public GameObject cloak;
    public List<ParticleCollisionEvent> collisionEvents;

	void Start() {
        collisionEvents = new List<ParticleCollisionEvent>();
	}	


     void OnParticleCollision(GameObject other)
    {
        ParticleSystem particleSys = other.GetComponent<ParticleSystem>();

        int numCollisionEvents = particleSys.GetCollisionEvents(gameObject, collisionEvents);

        /*int i = 0;

        while (i < numCollisionEvents) {
            if (GetComponent<Rigidbody>()) {
                Vector3 pos = collisionEvents[i].intersection;
                Vector3 force = collisionEvents[i].velocity * 10;
                GetComponent<Rigidbody>().AddForce(force);
            }
            i++;
        }*/

        //Debug.Log("Damaging enemy by " + numCollisionEvents);

        

        Damage(numCollisionEvents);
    }

    private void Awake()
    {
        currentHealth = maxHealth;
        //color = gameObject.GetComponent<Renderer>().material.color;
        cloak = gameObject.transform.Find("Cloak").gameObject;
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public void SetHealth(int health)
    {
        currentHealth = health;
        gameObject.GetComponent<MeshRenderer>().material.color -= new Color(0,0,0, (float)0.2 + (float)health /maxHealth);
        cloak.GetComponent<SkinnedMeshRenderer>().material.color -= new Color(0, 0, 0, (float)0.2 + (float)health / maxHealth);
    }

    public void Damage(int damage) 
    {
        //colour will change on update anyway
        currentHealth -= damage;
        transientHealthLoss += damage;
    }







    void Update()
    {
        //testing that the system works
        Color c = gameObject.GetComponent<Renderer>().material.color;
        c = new Color(c[0], c[1], c[2], (float)0.2 +(float)currentHealth / maxHealth);
        //Debug.Log(currentHealth / maxHealth);
        gameObject.GetComponent<MeshRenderer>().material.color = c;
        cloak.GetComponent<SkinnedMeshRenderer>().material.color = c;


        if (currentHealth <= 0) {
            Death();
        }
    }

    void Death()
    {
        gameObject.SetActive(false);
    }
}
