using UnityEngine;
using System.Collections;

public class Zellen : MonoBehaviour {


Vector3 posstart; //Position am Anfang des Fressvorgangs
public float zeitseitstart = 0f; //Zeit seit Beginn des Fressvorgangs
	void Update(){ //Leitet Fressvorgang ein
		if (transform.parent.tag == "Player") {
			StartCoroutine (Zerstören());
		}
	}
IEnumerator Zerstören() {
	zeitseitstart += Time.deltaTime; //Beginnt die Zeit zu zählen
	posstart = transform.position; //Legt die Ausgangsposition fest
	transform.position = Vector3.Lerp (posstart,transform.parent.transform.position, zeitseitstart/100f); //Bewegt die Zelle zur Position des Virus
	yield return new WaitForSeconds(5f); //			
	Destroy(this.gameObject); //Zerstört Zelle
	zeitseitstart = 0f; //Setzt Timer zurück
	}
}
