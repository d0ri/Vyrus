using UnityEngine;
using System.Collections;

public class Farbe1aus6 : MonoBehaviour {

	public int zahl;
		public Color[] farben = new Color[5]; //Liste von 5 verschiedenen Farben
	void Start () {
		//GetComponent<Renderer> ().material.SetColor ("_SpecColor", farben [(Random.Range (0, zahl))]); //Zufällige Auswahl aus den 6 Farben
		GetComponent<Renderer> ().material.SetColor ("_Color", farben [(Random.Range (0, zahl))]); //Zufällige Auswahl aus den 6 Farben
	}
}