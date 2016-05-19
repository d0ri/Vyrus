using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spritze : MonoBehaviour {
	Material spritzeM;
	Material virusM;
	GameObject[] Antis; //vorhandene Antikoerper
	//float timer = 0f;

	float forschung;
	public Image balken;
	float zyklus =1f;
	bool laeuft = true; //gibt an ob gerade die Forschung läuft

	int antianzahl = 50;
	public GameObject[] Antikoerper; //Prefab Antikoerper 

	void Start () {
		forschung = 0f;
		balken.fillAmount = forschung;
	}

	void Update () {
		Antis = GameObject.FindGameObjectsWithTag ("Anti");//zählt vorhandene Antikoerper
		spritzeM = transform.GetChild (0).transform.GetChild (0).gameObject.transform.GetComponent<Renderer> ().material;
		if (laeuft == true) {
			forschung += Time.deltaTime / (50f / zyklus);
		}
		balken.fillAmount = forschung;
		virusM = GameObject.FindGameObjectWithTag ("Player").GetComponent<Renderer> ().material;
		if (forschung >=1f) { //M-Taste nur für Testzwecke
			StartCoroutine (Spritzvorgang()); //Spritzvorgang auslösen
		}
		if (Antis.Length < antianzahl) {
			Instantiate (Antikoerper[(Random.Range(0,3))], new Vector3 (Random.Range(-160, 160), .1f, Random.Range(-190, 90)), Quaternion.identity);
		}

	}
	public IEnumerator Spritzvorgang ()
	{
		transform.GetChild (1).gameObject.SetActive (false); //schaltet balken ab
		laeuft = false;
		if (zyklus <= 25f) {
			zyklus += .5f;
		}
		forschung = 0f;
		transform.GetChild (0).gameObject.SetActive (true);
		spritzeM.color = virusM.GetColor ("_SpecColor");
		spritzeM.SetColor ("_EmissionColor", virusM.GetColor ("_SpecColor"));
		Antis = GameObject.FindGameObjectsWithTag ("Anti"); //sucht nach allen Antikoerpern
		foreach (GameObject antikoerper in Antis) { //Fuer alle Antikoerper
			antikoerper.GetComponent<Renderer> ().material.color = virusM.GetColor ("_SpecColor"); //antikörper erhalten die Farbe des Virus
		}
		yield return new WaitForSeconds (7); //wartet 7 sekunden
		transform.GetChild (0).gameObject.SetActive (false); //Spritze wird wieder ausgeschaltet

		yield return new WaitForSeconds (1);
		antianzahl += 10;
		transform.GetChild (1).gameObject.SetActive (true); // schaltet balken ein
		laeuft = true;
	}
}