using UnityEngine;
using System.Collections;

public class MagnetVirus : MonoBehaviour {

	public bool nag = false; // magnetisch ja/nein
	float countdown = 10.0f;



	void OnTriggerEnter(Collider other){

		if (other.tag == "Magnet") {
			nag = true;
			Destroy (other.gameObject);}//gameobject ergänzt (alex)




	}




	// 
	void Update () {
		if (nag == true) {//= ergänzt (alex)	//
			countdown -= Time.deltaTime;}		//
		if (countdown <= 0) { 					// in Update verschoben (alex)
			nag = false;						//
			countdown = 10.0f;}					//
	}
}
