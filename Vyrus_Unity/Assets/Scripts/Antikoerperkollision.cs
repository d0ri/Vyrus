using UnityEngine;
using System.Collections;

public class Antikoerperkollision : MonoBehaviour {
	public AudioClip Fressgeräusch;
	public AudioClip AntikörperTrifftSound;
		
	void OnTriggerEnter(Collider other){
		if (other.transform.tag == "Anti") {
			Destroy (other.gameObject);
			if (GetComponent<Makrophagenskript> ().mak == false) {
				transform.localScale = (transform.localScale -= new Vector3 (.1f, .1f, .1f)) * 0.9f;
				AudioSource.PlayClipAtPoint (AntikörperTrifftSound, transform.position);
			}
			if (GetComponent<Makrophagenskript> ().mak == true) {
				transform.localScale += new Vector3 (20f, 20f, 20f);
				AudioSource.PlayClipAtPoint (Fressgeräusch, transform.position);
			}
		}
	}
}