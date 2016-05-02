using UnityEngine;
using System.Collections;

public class Antikoerperbewegung : MonoBehaviour {

	GameObject Virus; //Virus
	Vector3 direction; //Vektor von Antikörper zu Virus
	float speed; //Variable Geschwindigkeit
	public float baseSpeed = 1f; //Grundgeschwindigkeit
	public float speedfactor = .1f; //Multiplikator Geschwindigkeit
	Color virCol; //Farbe Virus
	Color antiCol; //Farbe Antikörper
	float r; //Farbunterschied roter Kanal
	float g; //--grüner Kanal
	float b; //--blauer Kanal
	float rgbo; //--RGB unterschied (0, 3)
	Vector3 erratic; //Zufallskomponente der Bewegung
	float timer = 0f; //Timer
	public float duration = 5f; //Dauer bis Richtungsänderung

	void Start () {
		Virus = GameObject.FindGameObjectWithTag ("Player"); //findet Virus mit Tag
		timer = duration; // für Vektorberechnung bei Start

		//ZUFALLSFARBE!
		GetComponent<Renderer> ().material.color = new Color (Random.value, Random.value, Random.value);
		//TEST!
	}


	void Update () {
		direction = (Virus.transform.position - transform.position); //berechnet Vektor von Antikörper zu Virus

		virCol = Virus.GetComponent<Renderer>().material.color; //Definition virMat
		antiCol = GetComponent<Renderer>().material.color; //Definition antiMat
		r = Mathf.Abs(virCol.r - antiCol.r); //berechnet Farbunterschied roter Kanal
		g = Mathf.Abs(virCol.g - antiCol.g); //--grüner Kanal
		b = Mathf.Abs(virCol.b - antiCol.b); //--blauer kanal
		rgbo = 3f - (r+g+b); //--RGB unterschied (0, 3)
		speed = baseSpeed + speedfactor * rgbo; //Geschwindigkeit berechnen

		if (timer <= duration) {
			timer += Time.deltaTime; //zählt
		} else {
			erratic = new Vector3 (Random.Range(-1f,1f), 0, Random.Range(-1,1f)); //berechnet Zufallsvektor 
			timer = 0; //setzt Timer zurück
		}

		if (rgbo <= 2f){
			GetComponent<Rigidbody>().AddForce(erratic.normalized*baseSpeed, ForceMode.VelocityChange); //für großen Unterschied
		}
			else {
			GetComponent<Rigidbody>().AddForce(direction.normalized*speed, ForceMode.VelocityChange); //für kleinen Unterschied
			}
	}
}
