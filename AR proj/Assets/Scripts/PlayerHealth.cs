using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class PlayerHealth : MonoBehaviour
{
    // Use this for initialization
    public int maxHealth = 100;
    public int currentHealth;

    //green part
    public GameObject healthIndicator;
    //red part
    public GameObject healthIndicatorinv;

    //the materials
    private Material indicatorMaterial;
    private Material indicatorMaterialinv;

    //a handle to get at tracker position
    public GameObject ARcameraManager;
    private UnityARCameraManager UnityARCameraManager;

    //gameobject for bars to be childed to - allows manipulations in normal space, so bars are horizontal
    public GameObject Indicator;

    //camera to point at
    public Camera cam;


    private void Start()
    {
        //get private variables - instantiated materials and script
        indicatorMaterial = healthIndicator.GetComponent<MeshRenderer>().material;
        indicatorMaterialinv = healthIndicatorinv.GetComponent<MeshRenderer>().material;
        UnityARCameraManager = ARcameraManager.GetComponent<UnityARCameraManager>();

        //setup health
        SetHealth(maxHealth);
    }

    private void Awake()
    {
        
        //indicatorMaterial = healthIndicator.GetComponent<MeshRenderer>().material;
        //indicatorMaterialinv = healthIndicatorinv.GetComponent<MeshRenderer>().material;
        //UnityARCameraManager = ARcameraManager.GetComponent<UnityARCameraManager>();
        //SetHealth(maxHealth);
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public void SetHealth(int health)
    {
        //main way to change health.
        currentHealth = health;
        indicatorMaterial.SetFloat("_cutoff", 1f - ((float)currentHealth / (float)maxHealth));
        indicatorMaterialinv.SetFloat("_cutoff", ((float)currentHealth / (float)maxHealth));
    }


    // Update is called once per frame
    void Update()
    {
        //set transform to be towards cameras
        Indicator.transform.position = UnityARCameraManager.tracker_position;

        //TESTING ONLY -- updates when changed in editor
        indicatorMaterial.SetFloat("_Cutoff", 1f - (float)currentHealth / (float)maxHealth);
        indicatorMaterialinv.SetFloat("_Cutoff", (float)currentHealth / (float)maxHealth);
        Indicator.transform.LookAt(cam.transform);
    }

    void Death()
    {

    }
}