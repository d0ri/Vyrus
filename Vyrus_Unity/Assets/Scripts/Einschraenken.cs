﻿using UnityEngine;
using System.Collections;

public class Einschraenken : MonoBehaviour {

	public GameObject virus;
	public float langsamkeit = 1f;
	public float dauer = 3f;
	public AudioClip Bremsgeräusch;

	void start(){
		//virus = GameObject.FindGameObjectWithTag ("Player");
	}


	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			//Debug.Log ("COLLISSION");
			StartCoroutine (Freeze());
		}
	}

	IEnumerator Freeze ()
	{
		virus.GetComponent<VirusBewegung> ().moveSpeed /= langsamkeit;
		yield return new WaitForSeconds (dauer);
		virus.GetComponent<VirusBewegung>().moveSpeed *= langsamkeit;
		AudioSource.PlayClipAtPoint (Bremsgeräusch, transform.position);
	}
}
