﻿using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	public Difficulty difficulty;

    private SteamVR_TrackedController trackedObj;
    public GameObject mainMenu;
	public GameObject optionsMenu;
    public GameObject difficultyTextObject;
    public GameObject VRHeadset;

    
    //Need the VRHeadset object so that we can query its position
    //We will display the menu in front of the player
    
    private Text difficultyText;
    private GameManager gameManager;
    private bool mainMenuShowing = false;
    private bool optionsMenuShowing = false;
    private bool lastMenuButtonState = false;

    // Use this for initialization
    void Start () {
		optionsMenu.SetActive (optionsMenuShowing);
        difficultyText = difficultyTextObject.GetComponent<Text>();
        gameManager = FindObjectOfType<GameManager>();

        ChangeDifficulty((int)Difficulty.Medium);
	}

    private void Update()
    {
        if (WasMenuClicked()) {
            //Debug.Log("Menu button pressed");
            if (mainMenuShowing) {
                HideMenu();
            } else { 
                ShowMenu();
            }
        }
    }

    //Check whether menu button on controller has been pressed
    private bool WasMenuClicked()
    {
        bool currentMenuButtonState = Controller.GetPress(SteamVR_Controller.ButtonMask.ApplicationMenu);
        if (currentMenuButtonState != lastMenuButtonState)
        {
            lastMenuButtonState = currentMenuButtonState;
            return currentMenuButtonState;
        }
        return false;
    }

    //Calculate where the menu should appear then toggle its parent gameobject
    private void ShowMenu()
    {
        float dist = 4.0f; //How far from the player the menu should be
        Vector3 menuOffset = new Vector3(0.0f, 1.0f, 0.0f); //menu should not be in a vertical plane imo

        Vector3 forward = Quaternion.Euler(0.0f, VRHeadset.transform.rotation.eulerAngles.y, 0.0f) * Vector3.forward;
        Vector3 menuPos = forward * dist + VRHeadset.transform.position + menuOffset;
        Quaternion menuRot = Quaternion.LookRotation(menuPos - VRHeadset.transform.position, Vector3.up);

        mainMenu.transform.parent.position = menuPos;
        mainMenu.transform.parent.rotation = menuRot;


        //mainMenu.transform.parent.LookAt(VRHeadset.transform.position); // This flips menu

        mainMenuShowing = true;
        mainMenu.SetActive(true);

    }
    private void HideMenu()
    {
        mainMenuShowing = false;
        mainMenu.SetActive(false);

        optionsMenuShowing = false;
        optionsMenu.SetActive(false);
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedController>();
    }
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.controllerIndex); }
    }

    public void ToggleOptions() {
		optionsMenuShowing = !optionsMenuShowing;
		optionsMenu.SetActive (optionsMenuShowing);
	}

	public void ChangeDifficulty (int i) {
        Difficulty difficulty = (Difficulty)i;

		Debug.Log ("Difficulty changed to " + difficulty.ToString());
        difficultyText.text = "Difficulty: " + difficulty.ToString();

        gameManager.ChangeDifficulty(difficulty);
	}
    
		
}