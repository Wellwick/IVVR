using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script has a cog icon instead of a script icon in unity
 * but it should work fine nonetheless
 * This may be because of a native Unity script somewhere 
 */

public class GameManager : MonoBehaviour {

    private bool paused = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//check winning condition
	}

    public void ChangeDifficulty(int difficulty)
    {

    }


    public void StartGame()
    {
        Debug.Log("starting new game");
    }

    public void TogglePause()
    {
        if (paused) {
            ResumeGame();
            paused = false;
        } else {
            PauseGame();
            paused = true;
        }
    }

    private void PauseGame()
    {
        Debug.Log("Pausing game");
    }
    private void ResumeGame()
    {
        Debug.Log("Resuminmg game");
    }

}
