﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Sterben : MonoBehaviour {

	public GameObject TexturePlane; // Plane mit Videotextur "Game Over"
	public GameObject Musik;
	public AudioClip Sterbesound;
	public ParticleSystem partsys;

	void Update () {
		if (transform.localScale.x <= 40.0f){
			StartCoroutine (Stirb ());
			Sterbesound = GetComponent<AudioSource> ().clip;
		}
	}
	IEnumerator Stirb() {
		Musik.SetActive (false);
		GetComponent<Renderer> ().enabled = false;
		partsys.gameObject.SetActive (true);
		transform.GetComponent<AudioSource> ().clip = Sterbesound;
		if (transform.GetComponent<AudioSource>().isPlaying==false){
		transform.GetComponent<AudioSource> ().Play ();
		}
		yield return new WaitForSeconds(2f);
		TexturePlane.SetActive (true);
		//got = TexturePlane.GetComponent<Renderer> ().material.mainTexture;
		//got.Play (); //obsolet

		yield return new WaitForSeconds(3f); //
		TexturePlane.SetActive (false);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
