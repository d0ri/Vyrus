using UnityEngine;
using System.Collections;

public class Farbe : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter (Collider other){
		if (other.transform.tag == "Anti") {
			GetComponent<Renderer> ().material.color = Color.cyan;
			Destroy (other.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
