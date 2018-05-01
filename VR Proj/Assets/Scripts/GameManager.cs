using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum Difficulty : byte
{
    Easy = 1,
    Medium = 2,
    Hard = 3,
    Impossible = 4
}
public enum GameState : byte
{
    NoGame = 0,
    Paused = 1,
    Active = 2,
    Won = 3,
    Lost = 4
}

/*
 * This script has a cog icon instead of a script icon in unity
 * but it should work fine nonetheless
 * This may be because of a native Unity script somewhere 
 */
public class GameManager : MonoBehaviour
{
    public GameObject hengeObject;
    public Difficulty difficulty;

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

    public void ChangeDifficulty(Difficulty difficulty)
    {
        //Difficulty depends on enemy spawn rate and health and starting runes
        enemyManager = FindObjectOfType<EnemyManager>();
        this.difficulty = difficulty;

        switch (difficulty)
        {
            case Difficulty.Easy:
                enemyManager.enemyStartingHealth = 800;
                enemyManager.spawnInterval = 10.0f;
                henge.startingRunes = 12;
                break;
            case Difficulty.Medium:
                enemyManager.enemyStartingHealth = 1200;
                enemyManager.spawnInterval = 8.0f;
                henge.startingRunes = 6;
                break;
            case Difficulty.Hard:
                enemyManager.enemyStartingHealth = 1600;
                enemyManager.spawnInterval = 4.0f;
                henge.startingRunes = 0;
                break;
        }

    }


    public void StartGame()
    {
        Debug.Log("starting new game");

        gameState = GameState.Active;

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
