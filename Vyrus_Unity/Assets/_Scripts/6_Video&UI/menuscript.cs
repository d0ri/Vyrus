using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuscript : MonoBehaviour {

	public Canvas pauseMenu;
	public Button exitText;
	public Button continueText;

	void Start () {
		pauseMenu = pauseMenu.GetComponent<Canvas> ();
		exitText = exitText.GetComponent<Button>();
		continueText = continueText.GetComponent<Button> ();
		pauseMenu.enabled = false;
	}
	
	public void PausePress(){
		pauseMenu.enabled = true;
		exitText.enabled = false;
		Time.timeScale = 0;
	}

	public void ContinuePress(){
		pauseMenu.enabled = false;
		exitText.enabled = true;
		Time.timeScale = 1;
	}

	public void RestartLevel(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		Time.timeScale = 1;
	}

	public void ExitGame(){
		Application.Quit ();
	}
}
