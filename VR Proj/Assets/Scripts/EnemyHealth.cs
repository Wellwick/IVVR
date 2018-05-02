using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class EnemyHealth : MonoBehaviour {
    
    public int maxHealth = 100;
    public int currentHealth;
    public int transientHealthLoss;
    public GameObject cloak;
    public GameObject[] drops;
    private bool runeDrop = true;

    private float alpha;
    private GameManager gameManager; 


    private void Awake()
    {
        currentHealth = maxHealth;
        //color = gameObject.GetComponent<Renderer>().material.color;
        cloak = gameObject.transform.Find("Cloak").gameObject;

        gameManager = FindObjectOfType<GameManager>();
        runeDrop = true;
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
        // This is probably not needed; if AR is able to transmit damage messages
        // then that means it is connected, therefore it should have received pause update
        if (gameManager.GetGameState() == GameState.Paused) { return; }

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
        //Debug.Log(currentHealth / maxHealth);
        gameObject.GetComponent<MeshRenderer>().material.color = c;
        cloak.GetComponent<SkinnedMeshRenderer>().material.color = c;
        if(currentHealth <= 0){
            Death();
        }

    }

    private void DamageSelf()
    {
        Damage(maxHealth/20);
    }

    public void SlowDeath () 
    {
        float interval = 0.05f;                 // rate at which the enemy's health will drop
        InvokeRepeating("DamageSelf", 0.0f, interval);
        runeDrop = false;
    }

    void Death(){
		int selection = Random.Range(0,drops.Length);
        GameObject drop = GameObject.FindObjectOfType<Henge>().GetItemDrop();
        if (drop != null && runeDrop)
            GameObject.Instantiate(drop, transform.position, transform.rotation);
        GameObject.FindObjectOfType<EnemyManager>().enemyCount--;
        Destroy(gameObject);
    }
}