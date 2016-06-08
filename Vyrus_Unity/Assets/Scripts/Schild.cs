using UnityEngine;
using System.Collections;

public class Schild : MonoBehaviour {
	float countdown = 10.0f;
	public bool SchildAktiv = false; 
	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter (Collider other) {
		if (other.transform.tag == "Schild") {
			Destroy (other.gameObject);
			SchildAktiv = true;
		}
		}
		
	
	// Update is called once per frame
	void Update () {
		if (SchildAktiv == true){
			countdown -= Time.deltaTime;
		}
		if (countdown <= 0){
			SchildAktiv = false;
			countdown = 10.0f;
		}
		transform.GetChild (1).gameObject.SetActive (SchildAktiv);
	}
}
