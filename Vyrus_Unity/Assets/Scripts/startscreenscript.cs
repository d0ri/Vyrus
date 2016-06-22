using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class startscreenscript : MonoBehaviour {
	public Canvas can;
	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			Time.timeScale = 1;
			can.enabled = false;
		}
	}
}
