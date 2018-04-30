using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script has a cog icon instead of a script icon in unity
 * but it should work fine nonetheless
 * This may be because of a native Unity script somewhere 
 */
public class GameManager : MonoBehaviour
{
    private EnemyManager enemyManager;
    private bool paused = false;

	// Use this for initialization
	void Start () {
        enemyManager = FindObjectOfType<EnemyManager>();
	}
	
	// Update is called once per frame
	void Update () {
		//check winning condition
	}

    public void ChangeDifficulty(int difficulty)
    {
        //Difficulty depends on enemy spawn rate and health

        switch (difficulty)
        {
            case 1:
                enemyManager.startingHealth = 800;
                enemyManager.spawnInterval = 10.0f;
                break;
            case 2:
                enemyManager.startingHealth = 1200;
                enemyManager.spawnInterval = 8.0f;
                break;
            case 3:
                enemyManager.startingHealth = 1600;
                enemyManager.spawnInterval = 6.0f;
                break;
        }

    }


    public void StartGame()
    {
        Debug.Log("starting new game");
        //Reset Henge
        //Delete active enemies


        enemyManager.StartSpawning();
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
        enemyManager.PauseSpawning();
        PauseBeams();


        Debug.Log("Pausing game");
    }
    private void ResumeGame()
    {
        enemyManager.StartSpawning();
        ResumeBeams();

        Debug.Log("Resuminmg game");
    }

    private void PauseBeams()
    {
        Beam[] beams = FindObjectsOfType<Beam>();

        foreach (Beam beam in beams) {
            beam.PauseEmitting();
        }
    }
    private void ResumeBeams()
    {
        Beam[] beams = FindObjectsOfType<Beam>();

        foreach (Beam beam in beams)
        {
            beam.ResumeEmitting();
        }
    }

    public bool IsPaused()
    {
        return paused;
    }
}
