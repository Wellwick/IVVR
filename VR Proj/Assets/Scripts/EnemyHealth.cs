using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class EnemyHealth : MonoBehaviour {

    // Use this for initialization
    public int maxHealth = 100;
    public int currentHealth;
    //public Color color;
    private float alpha;
    public GameObject cloak;
    
    //private MeshRenderer meshRenderer; 


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
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //testing that the system works
        Color c = gameObject.GetComponent<Renderer>().material.color;
        c = new Color(c[0], c[1], c[2], (float)0.2 +(float)currentHealth / maxHealth);
        Debug.Log(currentHealth / maxHealth);
        gameObject.GetComponent<MeshRenderer>().material.color = c;
        cloak.GetComponent<SkinnedMeshRenderer>().material.color = c;
        if(currentHealth <= 0){
            Death();
        }

    }

    void Death(){
        Destroy(gameObject);
    }
}