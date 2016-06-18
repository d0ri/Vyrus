using UnityEngine;
using System.Collections;

public class restart : MonoBehaviour {

	public Canvas pausePanel;
	public Button restart;

	public void restartCurrentScene() {

	}
	void Start () {

		pausePanel = pausePanel.GetComponent<Canvas> ();
		restart = restart.GetComponent<Button> ();

	}

	public void ExitPress()
	{
		pausePanel.enabled = true;
		restart.enabled = false;
	}

	public void NoPress()
	{
		pausePanel.enabled = false;
		restart.enabled = true;
	}

	public void StartLevel()
	{
		Application.loadedLevel();
	}

}
