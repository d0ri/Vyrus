using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spritze : MonoBehaviour {
	Material spritzeM;
	Material virusM;
	GameObject[] Antis; //vorhandene Antikoerper
	public GameObject Musik;
	public AudioClip Spritzensound;
	public Vector3[] Spawn = new Vector3[7]; //Punkte an denen Antikoerper spawnen können
	//float timer = 0f;

	float forschung;
	public Image balken;
	float zyklus =1f;
	bool laeuft = true; //gibt an ob gerade die Forschung läuft

	int antianzahl = 20;
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
			Instantiate (Antikoerper[(Random.Range(0,3))], (Spawn[(Random.Range(0,7))])+new Vector3(10*Random.value,0,10*Random.value), Quaternion.identity);
		}

	}
	public IEnumerator Spritzvorgang ()
	{
		Musik.SetActive (false);
		transform.GetChild (1).gameObject.SetActive (false); //schaltet balken ab
		laeuft = false;
		if (zyklus <= 25f) {
			zyklus += .5f;
		}
		forschung = 0f;
		transform.GetChild (0).gameObject.SetActive (true);
		spritzeM.color = virusM.GetColor ("_SpecColor");
		spritzeM.SetColor ("_EmissionColor", virusM.GetColor ("_SpecColor"));
		AudioSource.PlayClipAtPoint (Spritzensound, transform.position);
		Antis = GameObject.FindGameObjectsWithTag ("Anti"); //sucht nach allen Antikoerpern
		foreach (GameObject antikoerper in Antis) { //Fuer alle Antikoerper
			antikoerper.GetComponent<Renderer> ().material.color = virusM.GetColor ("_SpecColor"); //antikörper erhalten die Farbe des Virus
		}
		yield return new WaitForSeconds (7); //wartet 7 sekunden
		transform.GetChild (0).gameObject.SetActive (false); //Spritze wird wieder ausgeschaltet

		yield return new WaitForSeconds (1);
		antianzahl += 3;
		transform.GetChild (1).gameObject.SetActive (true); // schaltet balken ein
		laeuft = true;
	}
}