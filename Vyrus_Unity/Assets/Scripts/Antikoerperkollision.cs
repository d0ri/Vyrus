using UnityEngine;
using System.Collections;

public class Antikoerperkollision : MonoBehaviour {
	public AudioClip Fressgeräusch;
	public AudioClip AnitkörperTrifftSound;
	// Use this for initialization
	void Start () {

	}

	void OnTriggerEnter(Collider other){

		if (other.transform.tag == "Anti") {
			transform.localScale = (transform.localScale -= new Vector3 (.1f, .1f, .1f)) * 0.9f;
			Destroy (other.gameObject);
			AudioSource.PlayClipAtPoint (AnitkörperTrifftSound, transform.position);
		}
		}

	// Update is called once per frame
		void Update () {
	
		
	}
}