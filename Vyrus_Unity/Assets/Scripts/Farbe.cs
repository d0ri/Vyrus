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
			zelle= other.GetComponent<Renderer> ().material.color; //Farbe der Zelle, ###!!!hier eventuell spaeter specColor verwenden falls Texturen verwendet werden###
			r = (4*old.r+zelle.r)/5; 
			g = (4*old.g+zelle.g)/5; //Mischt Wert im Verhältnis 4 zu 1
			b = (4*old.b+zelle.b)/5; 
			GetComponent<Renderer> ().material.SetColor ("_SpecColor", new Color (r, g, b, 0.7f));//neue Farbe
		}
	}
}
