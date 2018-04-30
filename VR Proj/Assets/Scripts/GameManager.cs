using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script has a cog icon instead of a script icon in unity
 * but it should work fine nonetheless
 * This may be because of a native Unity script somewhere 
 */


public enum GameState : byte
{
    NoGame = 0,
    Paused = 1,
    Active = 2,
    Won = 3,
    Lost = 4
}

public class GameManager : MonoBehaviour
{
    public GameObject hengeObject;

    private NetworkManager networkManager;
    private EnemyManager enemyManager;
    private Henge henge;
    private GameState gameState;

    // Use this for initialization
    void Start () {
        enemyManager = FindObjectOfType<EnemyManager>();
        networkManager = FindObjectOfType<NetworkManager>();
        henge = hengeObject.GetComponent<Henge>();
	}
	
	// Update is called once per frame
	void Update () {
		//check winning condition
        if (henge.IsComplete())
        {
            //we won the game
            KillEnemies();
        }
	}

    public void ChangeDifficulty(int difficulty)
    {
        //Difficulty depends on enemy spawn rate and health
        enemyManager = FindObjectOfType<EnemyManager>();

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

        KillEnemies();
        henge.Reset();
        


        enemyManager.StartSpawning();
    }

    public void TogglePause()
    {
       switch (gameState)
        {
            case GameState.NoGame:
                break;
            case GameState.Paused:
                ResumeGame();
                break;
            case GameState.Active:
                PauseGame();
                break;
            
        }

        BroadCastGameStateInfo();
    }

    private void PauseGame()
    {
        enemyManager.PauseSpawning();
        PauseBeams();

        gameState = GameState.Paused;

    }
    private void ResumeGame()
    {
        enemyManager.StartSpawning();
        ResumeBeams();

        gameState = GameState.Active;

    }

    public void BroadCastGameStateInfo()
    {
        networkManager.BroadcastGameStateInfo(gameState);
    }

    private void KillEnemies()
    {
        EnemyHealth[] enemies = FindObjectsOfType<EnemyHealth>();
        foreach (EnemyHealth enemy in enemies)
        {
            //Set all enemies to die smoothly in one second
            enemy.SlowDeath();
        }
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

    public GameState GetGameState()
    {
        return gameState;
    }
}
