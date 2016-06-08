using UnityEngine;
using System.Collections;

public class Schild : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter (Collider other) {
		if (other.transform.tag == "Schild") {
			Destroy (other.gameObject);
			GameObject.FindGameObjectWithTag ("Schutz").SetActive (true);
		}
		}
		
	
	// Update is called once per frame
	void Update () {
	
	}
}
