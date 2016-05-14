using UnityEngine;
using System.Collections;

public class Farbe1aus6 : MonoBehaviour {
		public Color[] farben = new Color[5]; //Liste von 5 verschiedenen Farben
	void Start () {
		GetComponent<Renderer> ().material.SetColor ("_SpecColor", farben [(Random.Range (0, 5))]); //Zufällige Auswahl aus den 6 Farben
	}
}
