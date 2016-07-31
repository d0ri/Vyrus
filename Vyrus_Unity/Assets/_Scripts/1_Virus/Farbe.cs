using UnityEngine;
using System.Collections;

public class Farbe : MonoBehaviour {

	float r;
	float g;
	float b;
	public Color old;
	public Color zelle;

	void OnTriggerEnter (Collider other){

		if (other.transform.tag == "Zelle") {
			old = GetComponent<Renderer> ().material.GetColor("_SpecColor") ; //aktuelle Farbe
			zelle= other.GetComponent<Renderer> ().material.GetColor("_Color"); //Farbe der Zelle, ###!!!hier eventuell spaeter specColor verwenden falls Texturen verwendet werden###
			r = (6*old.r+zelle.r)/7; 
			g = (6*old.g+zelle.g)/7; //Mischt Wert im Verhältnis 9 zu 1
			b = (6*old.b+zelle.b)/7; 
			GetComponent<Renderer> ().material.SetColor ("_SpecColor", new Color (r, g, b, 0.7f));//neue Farbe
			GetComponent<Renderer> ().material.SetColor ("_EmissionColor", new Color (r, g, b, 0.7f));//neue Emmission-Farbe
		}
	}
	void Update(){//für die Minimap
		Renderer mrend = transform.GetChild (3).GetComponent<Renderer> ();
		mrend.material = GetComponent<Renderer> ().material;
	}
}
