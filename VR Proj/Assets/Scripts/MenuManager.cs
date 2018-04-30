using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	private bool optionShowing = false;
	public int difficulty;

	public GameObject mainPanel;
	public GameObject optionsMenu;
    public GameObject difficultyTextObject;

    private Text difficultyText;
    private GameManager gameManager;

	// Use this for initialization
	void Start () {
		optionsMenu.SetActive (optionShowing);
        difficultyText = difficultyTextObject.GetComponent<Text>();
        gameManager = FindObjectOfType<GameManager>();

        ChangeDifficulty(1);
	}

    

	public void ToggleOptions() {
		optionShowing = !optionShowing;
		optionsMenu.SetActive (optionShowing);
	}

	public void ChangeDifficulty (int i) {
		// 1: Easy; 2:Medium; 3:Hard
		difficulty = i;
        string diffstr;
        switch (difficulty)
        {
            case 1: diffstr = "Easy";       break;
            case 2: diffstr = "Medium";     break;
            case 3: diffstr = "Hard";       break;
            default: diffstr = "Unknown";   break;
        }
		Debug.Log ("Difficulty changed to " + diffstr);
        difficultyText.text = "Difficulty: " + diffstr;

        gameManager.ChangeDifficulty(i);
	}

	public void Quit() {
		mainPanel.SetActive (false);
	}
		
}
