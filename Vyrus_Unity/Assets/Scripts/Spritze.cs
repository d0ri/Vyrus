using UnityEngine;
using System.Collections;

public class Spritze : MonoBehaviour {
	Material spritzeM;
	Material virusM;
	GameObject[] Antis;
	float timer = 0f;

	void Start () {

	}

	void Update () {
		spritzeM = transform.GetChild (0).transform.GetChild (0).gameObject.transform.GetComponent<Renderer> ().material;
		virusM = GameObject.FindGameObjectWithTag ("Player").GetComponent<Renderer> ().material;
		if (Input.GetKeyDown (KeyCode.M)) { //M-Taste nur für Testzwecke
			
			StartCoroutine (Spritzvorgang()); //Spritzvorgang auslösen
		}
	}
	IEnumerator Spritzvorgang ()
	{
		transform.GetChild (0).gameObject.SetActive (true);
		spritzeM.color = virusM.GetColor ("_SpecColor");
		spritzeM.SetColor ("_EmissionColor", virusM.GetColor ("_SpecColor"));
		Antis = GameObject.FindGameObjectsWithTag ("Anti"); //sucht nach allen Antikoerpern
		foreach (GameObject antikoerper in Antis) { //Fuer alle Antikoerper
			antikoerper.GetComponent<Renderer> ().material.color = virusM.GetColor ("_SpecColor"); //antikörper erhalten die Farbe des Virus
		}
		yield return new WaitForSeconds (7); //wartet 7 sekunden
		transform.GetChild (0).gameObject.SetActive (false); //Spritze wird wieder ausgeschaltet
	}
}