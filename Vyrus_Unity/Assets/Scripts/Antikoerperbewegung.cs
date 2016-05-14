using UnityEngine;
using System.Collections;

public class Antikoerperbewegung : MonoBehaviour {

	GameObject Virus; //Virus
	Vector3 direction; //Vektor von Antikörper zu Virus
	public float speed; //Variable Geschwindigkeit
	public float baseSpeed = 1f; //Grundgeschwindigkeit
	public float speedfactor = .1f; //Multiplikator Geschwindigkeit
	Color virCol; //Farbe Virus
	Color antiCol; //Farbe Antikörper
	float r; //Farbunterschied roter Kanal
	float g; //--grüner Kanal
	float b; //--blauer Kanal
	public float rgbo; //--RGB unterschied (0, 3)
//	Vector3 erratic; //Zufallskomponente der Bewegung
	float timer = 0f; //Timer
	public float duration = 5f; //Dauer bis Richtungsänderung

	public Quaternion orientierung; // Orientierung des Antikörpers (Richtung Virus)
	public float drehung; //orientierung anpassen
	public int vorwaerts; //(1,2,3,4) drehung ausgleichen


	void Start () {
		Virus = GameObject.FindGameObjectWithTag ("Player"); //findet Virus mit Tag
		timer = duration; // für Vektorberechnung bei Start


		GetComponent<Renderer> ().material.color = Virus.GetComponent<Renderer>().material.GetColor("_SpecColor");

	}


	void OnTriggerEnter(Collider other){
		if (other.transform.tag == "Hindernis") {
			transform.rotation = Quaternion.Euler (0, 180f, 0);
		}
	}

	void Update () {
		direction = (Virus.transform.position - transform.position); //berechnet Vektor von Antikörper zu Virus

		virCol = Virus.GetComponent<Renderer>().material.GetColor("_SpecColor"); //Definition virMat
		antiCol = GetComponent<Renderer>().material.color; //Definition antiMat
		r = Mathf.Abs(virCol.r - antiCol.r); //berechnet Farbunterschied roter Kanal
		g = Mathf.Abs(virCol.g - antiCol.g); //--grüner Kanal
		b = Mathf.Abs(virCol.b - antiCol.b); //--blauer kanal
		rgbo = 2.5f*(3f - (r+g+b)); //--RGB unterschied (0, 3)
		//speed = baseSpeed + speedfactor * rgbo; //Geschwindigkeit berechnen


		if (timer <= duration) {
			timer += Time.deltaTime; //zählt
		} else {
			if(direction.magnitude >= 20f){; //berechnet Zufallsvektor
				transform.rotation = Quaternion.Euler(0,Random.value*45f,0);
			timer = 0; //setzt Timer zurück
			}
		}

		if (rgbo <= 2f || direction.magnitude >= 20f ){

			if(vorwaerts == 1){
				transform.position += transform.forward * Time.deltaTime * 1.5f; 
			}
			if(vorwaerts == 2){
				transform.position += transform.right * Time.deltaTime * 1.5f; 
			}
			if(vorwaerts == 3){
				transform.position += transform.forward * Time.deltaTime * -1f * 1.5f; 
			}
			if(vorwaerts == 4){
				transform.position += transform.right * Time.deltaTime * -1f * 1.5f; 
			}
		}
			else {

			orientierung = Quaternion.LookRotation(Virus.transform.position-transform.position)*Quaternion.Euler(0,drehung,0); //der antikoerper orientiert sich richtung virus
			transform.rotation = Quaternion.Lerp(transform.rotation,orientierung,.5f); //Lerp

			if(vorwaerts == 1){
				transform.position += transform.forward * Time.deltaTime * rgbo; 
			}
			if(vorwaerts == 2){
				transform.position += transform.right * Time.deltaTime * rgbo;
			}
			if(vorwaerts == 3){
				transform.position += transform.forward * Time.deltaTime * -1f * rgbo;
			}
			if(vorwaerts == 4){
				transform.position += transform.right * Time.deltaTime * -1f * rgbo; 
			}
			}
	}
}
