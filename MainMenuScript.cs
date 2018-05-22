using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

	public Canvas MainMenuCanvas;
	public Canvas HowToCanvas;


	void Start () {
		HowToCanvas.enabled = false;	
	}
		
	public void PlayOn() {
		//Open Game Scene
	}
	public void HowToOn() {
		HowToCanvas.enabled = true;
		MainMenuCanvas.enabled = false;
	}
	public void ReturnOn() {
		HowToCanvas.enabled = false;
		MainMenuCanvas.enabled = true;
	}
	public void QuitGame() {
		Application.Quit ();
	}
}
