using UnityEngine;
using System.Collections;

public class Makrophagenskript : MonoBehaviour {

		public AudioClip Fressgeräsch;
		float anzahl = 0f; // Anzahl gefressener Zellen
		public bool mak = false; // magnetisch ja/nein
		float countdown = 10.0f;
		GameObject makrophage;


		void OnTriggerEnter(Collider other){

			if (other.transform.tag == "Makrophage") {
				other.transform.parent = this.transform;
				other.GetComponent<Collider> ().enabled = false;
				AudioSource.PlayClipAtPoint (Fressgeräsch, transform.position,100);
					mak = true;
					makrophage = other.gameObject;
					makrophage.SetActive (false);
			        mak = false;
					//Destroy (other.gameObject);}

				

				
					if (mak == true) {	
						countdown -= Time.deltaTime;	
					}
					if (countdown <= 0) { 								                                  mak = false;						

						countdown = 10.0f;
					makrophage.SetActive (true);
					}					
				}

		 // magnetisch ja/nein





			}
		}

		



	
