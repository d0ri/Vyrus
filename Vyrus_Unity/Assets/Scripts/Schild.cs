using UnityEngine;
using System.Collections;

public class Schild : MonoBehaviour {
	float countdown = 10.0f;
	public bool SchildAktiv = false; 
	// Use this for initialization
	GameObject schildobject;
	void Start () {
		Physics.IgnoreLayerCollision (11,10);
	}

	void OnTriggerEnter (Collider other) {
		if (other.transform.tag == "Schild") {
			schildobject = other.gameObject;
			other.gameObject.SetActive (false);
			//Destroy (other.gameObject);
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
			schildobject.gameObject.SetActive (true);//schild taucht wieder auf nachdem powerup abgelaufen ist
		}
		transform.GetChild (1).gameObject.SetActive (SchildAktiv);
		Physics.IgnoreLayerCollision (0,8, SchildAktiv);//Gegner
		Physics.IgnoreLayerCollision (0,9, SchildAktiv);//Antikoerper
		//Physics.IgnoreLayerCollision (0,10, SchildAktiv);//Grund
	}
}
