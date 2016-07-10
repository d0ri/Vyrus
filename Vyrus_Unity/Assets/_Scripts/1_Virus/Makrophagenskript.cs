using UnityEngine;
using System.Collections;

public class Makrophagenskript : MonoBehaviour {

	public bool mak = false; // Powrup aktiv ja/nein
	float countdown = 10.0f;
	GameObject makrophage;

	void OnTriggerEnter(Collider other){
		if (other.transform.tag == "Makrophage") {
			mak = true;
			makrophage = other.gameObject;
			makrophage.SetActive (false);
		}
	}

	void Update(){
		if (mak == true) {	
			countdown -= Time.deltaTime;				
		}
		if (countdown <= 0) { 								             
		mak = false;						
		countdown = 10.0f;
		makrophage.SetActive (true);
		}					
	}
}