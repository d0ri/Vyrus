using UnityEngine;
using System.Collections;

public class MagnetVirus : MonoBehaviour {

	public bool mag = false; // magnetisch ja/nein
	float countdown = 10.0f;
	public AudioClip MagnetSound;
	GameObject magnetobject;


	void OnTriggerEnter(Collider other){

		if (other.tag == "Magnet") {
			mag = true;
			magnetobject = other.gameObject;
			magnetobject.SetActive (false);
			//Destroy (other.gameObject);}//gameobject ergänzt (alex)
		}
	}

	void Update () {
		if (mag == true) {//= ergänzt (alex)	//
			countdown -= Time.deltaTime;		//
			AudioSource.PlayClipAtPoint (MagnetSound, transform.position);
		}
		if (countdown <= 0) { 					// in Update verschoben (alex)
			mag = false;						//
			countdown = 10.0f;
			magnetobject.SetActive (true);
		}					
	}
}
