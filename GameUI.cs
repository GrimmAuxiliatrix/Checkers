using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour {

	public Canvas GameScreen;
	public Canvas WinScreen;
	public Canvas LoseScreen;

	private int blackcount;
	private int redcount;
	public Text blackcountText;
	public Text redcountText;

	// Use this for initialization
	void Start () {
		GameScreen.enabled = true;
		WinScreen.enabled = false;
		LoseScreen.enabled = false;

		blackcount = 0;
		redcount = 0;
		setBlackText ();
		setRedText();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void setBlackText() {
		blackcountText.text = "Black Capture Count: " + blackcount.ToString ();
	}
	void setRedText() {
		redcountText.text = "Red Capture Count: " + redcount.ToString ();
	}

	public void PlayAgain() {
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		Start ();
	}
	public void QuitButton() {
		SceneManager.LoadScene ("Main_Menu", LoadSceneMode.Single);
	}

	/*
	 * void pieceCaptured() {
	 * 	if(capturedpiece == red) {
	 * 		blackcount++;
	 * 		setBlackText();
	 * 	}
	 * 	if(capturepiece == black){
	 * 		redcount++;
	 * 		setRedText();
	 * 	}
	 * }
	 * 
	 * void playerWins() {
	 * 	GameScreen.enabled = false;
	 * 	WinScreen.enabled = true;
	 * }
	 * void computerWins() [
	 * 	GameScreen.enabled = false;
	 * 	LoseScreen.enabled = true;
	 * }
	 */
}
