using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spritze : MonoBehaviour {
	public Color Startfarbe;//Farbe des Virus zu Beginn
	Material spritzeM;
	Material virusM;
	GameObject[] Antis; //vorhandene Antikoerper
	//public GameObject Musik; <- nicht festgelegt(alex)
	public AudioClip Spritzensound;
	//public Vector3[] Spawn = new Vector3[7]; //Obsolet, stattdessen SpanPoint-Prefab verwenden
	//float timer = 0f;
	public Color Antikoerperfarbe;//aktuelle Farbe der Antikoerper
	float forschung;//Prozentangabe des Forschungsstandes
	public float forschungsdauer = 10f;//je höher, desto länger die Forschungsdauer
	public Image balken;
	bool laeuft = true; //gibt an ob gerade die Forschung läuft
	public GameObject[] Antikoerper; //Prefab Antikoerper 

	void Start () {
		forschung = 0f;
		balken.fillAmount = forschung;
		Antikoerperfarbe = Startfarbe;
	}

	void Update () {
		Antis = GameObject.FindGameObjectsWithTag ("Anti");//zählt vorhandene Antikoerper
		spritzeM = transform.GetChild (0).transform.GetChild (0).gameObject.transform.GetComponent<Renderer> ().material;
		if (laeuft == true) {
			forschung += Time.deltaTime * (1 / forschungsdauer);//zählt die Zeit hoch
		}
		balken.fillAmount = forschung;//Balkenfüllung abhängig von forschung
		virusM = GameObject.FindGameObjectWithTag ("Player").GetComponent<Renderer> ().material;
		if (forschung >=1f) { //wenn forschung beendet, dann...
			StartCoroutine (Spritzvorgang()); //Spritzvorgang auslösen
			//REDUNDANT, stattdessen SpawnPoints
			//for (int i=0; i < (antianzahl-Antis.Length); i++){
			//	Instantiate (Antikoerper[(Random.Range(0,3))], (Spawn[(Random.Range(0,7))])+new Vector3(10*Random.value,0,10*Random.value), Quaternion.identity);
			//}
		}
		Antis = GameObject.FindGameObjectsWithTag ("Anti"); //sucht nach allen Antikoerpern
		foreach (GameObject antikoerper in Antis) { //Fuer alle Antikoerper
			antikoerper.GetComponent<Renderer> ().material.color = Antikoerperfarbe;//weist aktuelle Farbe zu
		}
	}

	public IEnumerator Spritzvorgang ()
	{
		//Musik.SetActive (false); <- nicht festgelegt (siehe oben)(alex)
		transform.GetChild (1).gameObject.SetActive (false); //schaltet balken ab
		laeuft = false; //hält Forschung an
		//OBSOLET, stattdessen für einzelne Level verschiedene Forschunfsdauern festlegen
		//if (zyklus <= 25f) {
		//	zyklus += .5f;
		//}
		forschung = 0f;//setzt Forschung zurück
		transform.GetChild (0).gameObject.SetActive (true);//schaltet Spritze an
		spritzeM.color = virusM.GetColor ("_SpecColor");//Farbe der Spritze definiert durch Farbe des Virus
		spritzeM.SetColor ("_EmissionColor", virusM.GetColor ("_SpecColor"));//
		AudioSource.PlayClipAtPoint (Spritzensound, transform.position);
		//if (Antis.Length < antianzahl) {
		//	Instantiate (Antikoerper[(Random.Range(0,3))], (Spawn[(Random.Range(0,7))])+new Vector3(10*Random.value,0,10*Random.value), Quaternion.identity);
		//}
		Antikoerperfarbe = virusM.GetColor ("_SpecColor"); //antikörper erhalten die Farbe des Virus
		yield return new WaitForSeconds (7); //wartet 7 sekunden
		transform.GetChild (0).gameObject.SetActive (false); //Spritze wird wieder ausgeschaltet
		yield return new WaitForSeconds (1);//wartet eine Sekunde
		transform.GetChild (1).gameObject.SetActive (true); // schaltet balken ein
		laeuft = true;//setzt Forschung fort
	}
}