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
    private PlayerHealth playerHealth;
    private Henge henge;
    private GameState gameState;

    // Use this for initialization
    void Start () {
        Debug.Log("difficulty: " + gameState);
        enemyManager = FindObjectOfType<EnemyManager>();
        networkManager = FindObjectOfType<NetworkManager>();
        henge = hengeObject.GetComponent<Henge>();
        playerHealth = FindObjectOfType<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update () {

        
        if (gameState == GameState.Active || gameState == GameState.Paused) {
            // question: should we check for winning and losing condition if game is paused?
            // Do not check if the gameState is  Won/Lost/NoGame.

            // Losing conditions
            if (!playerHealth.IsAlive()) {
                gameState = GameState.Lost;
            }
            
            /*
            * Winning conditions:
            *      Player health > 0
            *      Henge completion = 100%
            *      Player is colliding with Portal object???
            */ 
            if (henge.IsComplete() && playerHealth.IsAlive()){
                //we won the game
                KillEnemies();
                gameState = GameState.Won;
            }
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
                henge.startingRunes = 8;
                break;
            case Difficulty.Medium:
                enemyManager.enemyStartingHealth = 1200;
                enemyManager.spawnInterval = 8.0f;
                henge.startingRunes = 4;
                break;
            case Difficulty.Hard:
                enemyManager.enemyStartingHealth = 1600;
                enemyManager.spawnInterval = 4.0f;
                henge.startingRunes = 2;
                break;
            case Difficulty.Impossible:
                //Currently cannot access this mode because there are only three buttons in the menu.
                enemyManager.enemyStartingHealth = 2400;
                enemyManager.spawnInterval = 4.0f;
                henge.startingRunes = 0;
                break;
        }

    }


    public void StartGame()
    {
        gameState = GameState.Active;

        KillEnemies(); 
        henge.Reset();
        playerHealth.Reset();
        enemyManager.StartSpawning();

    }

    public void Pause()
    {
       switch (gameState)
        {
            case GameState.NoGame:
                break;
            case GameState.Active:
                PauseBeams();
                gameState = GameState.Paused;
                break;
            case GameState.Paused:
                //ResumeBeams();
                //gameState = GameState.Active;
                break;
        }
    }

    public void Resume()
    {
        switch (gameState)
        {
            case GameState.NoGame:
                break;
            case GameState.Active:
                //PauseBeams();
                //gameState = GameState.Paused;
                break;
            case GameState.Paused:
                ResumeBeams();
                gameState = GameState.Active;
                break;
        }
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
