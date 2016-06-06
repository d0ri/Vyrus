using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class zellenfressen : MonoBehaviour {
	//public float wt =10.0f;// gibt an um wieviel der Virus wächst

	public AudioClip Fressgeräusch;
	public Text score; //ZellenScore
	float anzahl = 0f; // Anzahl gefressener Zellen
	void OnTriggerEnter(Collider other){
		
		if (other.transform.tag == "Zelle") {
			other.transform.parent = this.transform;
			transform.localScale = Vector3.one*(Mathf.Pow((Mathf.Pow(transform.localScale.x,3)+100000f),(1f/3f)));
			AudioSource.PlayClipAtPoint (Fressgeräusch, transform.position,100);
			anzahl++;
			score.text = ("Gefressene Zellen |" + anzahl.ToString ())+"|";
		}

	}
}