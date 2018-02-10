using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class PlayerHealth : MonoBehaviour {
    // Use this for initialization
    public int maxHealth = 100;
    public int currentHealth;
    public Slider healthSlider;


    private void Awake()
    {
        SetHealth(maxHealth);
        healthSlider.maxValue = maxHealth;
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public void SetHealth(int health)
    {
        currentHealth = health;
        healthSlider.value = currentHealth;
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        healthSlider.value = currentHealth;
    }

    void Death()
    {

    }
}