using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

	private bool optionShowing = false;
	public int difficulty;

	public GameObject mainPanel;
	public GameObject optionPanel;

	// Use this for initialization
	void Start () {
		optionPanel.SetActive (optionShowing);
	}

	public void PlayGame() {
		// Needs to get option settings and send them to relevant places

		Quit ();
	}

	public void ToggleOptions() {
		optionShowing = !optionShowing;
		optionPanel.SetActive (optionShowing);
	}

	public void ChangeDifficulty (int i) {
		// 0: Easy; 1:Medium; 2:Hard
		difficulty = i;	
		Debug.Log (difficulty);
	}

	public void Quit() {
		mainPanel.SetActive (false);
	}
		
}
