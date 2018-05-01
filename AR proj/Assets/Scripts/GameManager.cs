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

    private GameState gameState;
    private TextManager textManager;

    // Use this for initialization
    void Start () {
        textManager = FindObjectOfType<TextManager>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void HandleGameStateChanged(GameState gameState) {
        this.gameState = gameState;

        switch (gameState) {
            case GameState.NoGame :
                
                break;
            case GameState.Paused :
                textManager.UpdatePanelText("GAME PAUSED", true);
                Pause();
                break;
            case GameState.Active :
                textManager.UpdatePanelText("", false);
                Resume();
                break;
            case GameState.Won :
                textManager.UpdatePanelText("YOU WIN!", true);
                break;
            case GameState.Lost :
                textManager.UpdatePanelText("GAME OVER", true);

                break;
        }
    }

    	

    private void Pause()
    {
        Beam[] beams = FindObjectsOfType<Beam>();

        foreach (Beam beam in beams) {
            beam.Pause();
        }
    }
    private void Resume()
    {
        Beam[] beams = FindObjectsOfType<Beam>();

        foreach (Beam beam in beams)
        {
            beam.Pause();
        }
    }
    public  GameState GetGameState()
    {
        return gameState;
    }
}