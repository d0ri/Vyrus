using UnityEngine;
using System.Collections;

public class Gegnerbewegung : MonoBehaviour {

	Vector3 erratic;
	public float speed = .1f; //Mittlere Geschwindigkeit
	public float randomnessSpeed = .05f; //maximale zufällige Abweichung von der mittleren Geschwindigkeit
	float totalSpeed; // Gesamtgeschwindigkeit
	public float duration = 2f; //Dauer bis zum Richtungswechsel
	float timer = 0f; //Timer

	void Start () {
		timer = duration;
	}
		
	void Update () {
		GetComponent<Rigidbody>().AddForce(erratic.normalized*totalSpeed, ForceMode.VelocityChange); //Kraft in Richtung Zufallsvektor
		if (timer < duration) { // zählt hoch bis duration
			timer += Time.deltaTime;
		} else {
			erratic = new Vector3 (Random.Range(-1f,1f), 0, Random.Range(-1,1f)); //berechnet neuen Zufallsvektor
			totalSpeed = speed + Random.Range(-randomnessSpeed, randomnessSpeed); //rechnet zufällige Abweichung ein
			timer = 0; //setzt Timer zurück
		}
			
	}
}
