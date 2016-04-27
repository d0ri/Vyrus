using UnityEngine;
using System.Collections;

public class Antikörperbewegung : MonoBehaviour {

	GameObject Virus; //Virus
	Vector3 direction; //Vektor von Antikörper zu Virus
	float speed; //Variable Geschwindigkeit
	public float speedfactor = .1f; //Multiplikator Geschwindigkeit
	Color virCol; //Farbe Virus
	Color antiCol; //Farbe Antikörper
	float r; //Farbunterschied roter Kanal
	float g; //--grüner Kanal
	float b; //--blauer Kanal
	float rgbo; //--RGB unterschied (-1.5, 0, 1.5)
	Vector3 erratic; //Zufallskomponente der Bewegung

	void Start () {
		Virus = GameObject.FindGameObjectWithTag ("Player"); //findet Virus mit Tag

		//ZUFALLSFARBE
		GetComponent<Renderer> ().material.color = new Color (Random.value, Random.value, Random.value);
		//TEST
	}


	void Update () {
		direction = (Virus.transform.position - transform.position); //berechnet Vektor von Antikörper zu Virus

		virCol = Virus.GetComponent<Renderer>().material.color; //Definition virMat
		antiCol = GetComponent<Renderer>().material.color; //Definition antiMat
		r = Mathf.Abs(virCol.r - antiCol.r); //berechnet Farbunterschied roter Kanal
		g = Mathf.Abs(virCol.g - antiCol.g); //--grüner Kanal
		b = Mathf.Abs(virCol.b - antiCol.b); //--blauer kanal
		rgbo = 1.5f - (r+g+b); //--RGB unterschied (-1.5, 0, 1.5)
		speed = speedfactor * rgbo; //Geschwindigkeit berechnen

		if (rgbo <= 0){
			GetComponent<Rigidbody>().AddForce(erratic.normalized, ForceMode.VelocityChange); //für großen Unterschied
		}
			else {
			GetComponent<Rigidbody>().AddForce(direction.normalized*speed, ForceMode.VelocityChange); //für kleinen Unterschied
			}
		StartCoroutine(errChange()); // startet Coroutine
	}

	IEnumerator errChange(){
		erratic = new Vector3 (Random.Range(-1f,1f), 0, Random.Range(-1,1f)); //berechnet neuen Zufallsvektor
		yield return new WaitForSeconds(5f); //wartet 5 Sekunden
	}
}
