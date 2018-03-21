using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class PH2 : MonoBehaviour
{
    // Use this for initialization
    public int maxHealth = 100;
    public int currentHealth;
    public Slider healthSlider;

    public GameObject healthIndicator;
    public GameObject healthIndicatorinv;
    private Material indicatorMaterial;
    private Material indicatorMaterialinv;


    public GameObject Indicator;
    public Camera cam;


    private void Start()
    {
        SetHealth(maxHealth);
        // healthSlider.maxValue = maxHealth;
        indicatorMaterial = healthIndicator.GetComponent<MeshRenderer>().material;
        indicatorMaterialinv = healthIndicatorinv.GetComponent<MeshRenderer>().material;
    }

    private void Awake()
    {
        indicatorMaterial = healthIndicator.GetComponent<MeshRenderer>().material;
        indicatorMaterialinv = healthIndicatorinv.GetComponent<MeshRenderer>().material;
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public void SetHealth(int health)
    {
        currentHealth = health;
        // healthSlider.value = currentHealth;
        indicatorMaterial.SetFloat("_cutoff", 1f - ((float)currentHealth / (float)maxHealth));
        indicatorMaterialinv.SetFloat("_cutoff", ((float)currentHealth / (float)maxHealth));
    }


    // Update is called once per frame
    void Update()
    {
        //healthSlider.value = currentHealth;

        //indicatorMaterial = healthIndicator.GetComponent<MeshRenderer>().material;
        indicatorMaterial.SetFloat("_Cutoff", 1f - (float)currentHealth / (float)maxHealth);
        indicatorMaterialinv.SetFloat("_Cutoff", (float)currentHealth / (float)maxHealth);
        Indicator.transform.LookAt(cam.transform);
    }

    void Death()
    {

    }
}