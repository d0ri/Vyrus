using UnityEngine;
using System.Collections;

public class SchrumpfenueberZeit : MonoBehaviour {
	public AudioClip SchrumpfenSound;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Decrease", 0, .1f);
	}

	void Decrease () {   //Größe des Spielers nimmt ab bis 1.0
		if (transform.localScale.x >= 1f) {
			transform.localScale *= .995f;
			AudioSource.PlayClipAtPoint (SchrumpfenSound, transform.position);
		}
	}

}
