using UnityEngine;
using System.Collections;

public class pitch : MonoBehaviour {

	public GameObject Virus; // Virus
	float size; //Groesse des Virus (x-Achse)
	// Use this for initialization
	void Start () {
		size = Virus.transform.localScale.x;
	}

	// Update is called once per frame
	void Update () {

		size = Virus.transform.localScale.x;

		if (size <= 25){
			GetComponent<AudioSource> ().pitch = 1.75f;
		}
		if (size > 25 && size <= 50){
			GetComponent<AudioSource> ().pitch = 1.5f;
		}
		if (size > 50 && size <= 75){
			GetComponent<AudioSource> ().pitch = 1.25f;
		}
		if (size > 75 && size <= 100){
			GetComponent<AudioSource> ().pitch = 1.0f;
		}
		if (size > 100 && size <= 150){
			GetComponent<AudioSource> ().pitch = 0.8f;
		}
		if (size > 150){
			GetComponent<AudioSource> ().pitch = 0.6f;
		}
	}
}
