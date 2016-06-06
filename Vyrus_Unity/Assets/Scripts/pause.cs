using UnityEngine;
using System.Collections;

public class pause : MonoBehaviour {

    public GameObject pauseButton, pausePanel;

	public void Start()
	{
		OnUnpause();
	}	

	public void OnPause()
	{
		pausePanel.SetActive(true);
		pauseButton.SetActive(false);
		Time.timeScale = 0;
	}

	public void OnUnpause()
	{
		pausePanel.SetActive(false);
		pauseButton.SetActive(true);
		Time.timeScale = 1;
	}
}



