using UnityEngine;
using System.Collections;

public class Infektion : MonoBehaviour {

	public GameObject Organ;// welches Organ soll infiziert werden
	public Color Farbe = Color.green; // mit welcher Farbe soll das Organ infiziert werden; kann im Inspector eingestellt werden.
	public bool geschafft = false; //ist true wenn das Organ infiziert wurde
	public float genauigkeit; //wie genau muss die Farbe des Virus der "Farbe" entsprechen 0 = exakt die "Farbe muss erreicht werden", 3 = jede Farbe funktioniert
	Color Virusfarbe;
	float r, g, b; //drei floats für roten, grünen und blauen kanal;
	float countdown;
	public float dauer = 1.0f;//wie lange muss der Virus das Organ berühren um zu infizieren?



	// Use this for initialization
	void Start () {
		countdown = dauer;
	}

	void OnTriggerStay(Collider other){//countdown und particle an
		if (other.tag == Organ.tag ) {
			if((r + g + b) <= genauigkeit){
			countdown -= Time.deltaTime;
			transform.GetChild (2).gameObject.SetActive (true);//schaltet InfektionsPartikel des Virus AN
				transform.GetChild (2).gameObject.GetComponent<ParticleSystem> ().startColor = Farbe; //Partikelfarbe = "Farbe(TM)"
				Organ.transform.localScale = Vector3.Lerp (Organ.transform.localScale,new Vector3(0,0,0),Time.deltaTime/30);//Organ schrumpft
			}
		}
	}
	void OnTriggerExit(Collider other){//particle aus countdown zurücksetzen
		if (other.tag == Organ.tag) {
			countdown = dauer; //die im inspector eingestellte dauer definiert den countdown
			transform.GetChild (2).gameObject.SetActive (false);//schaltet InfektionsPartikel des Virus AUS
		}
	}

	// Update is called once per frame
	void Update () {
		Virusfarbe = GameObject.FindGameObjectWithTag ("Player").GetComponent<Renderer> ().material.GetColor ("_SpecColor");
		r = Mathf.Abs(Virusfarbe.r - Farbe.r); //berechnet Farbunterschied roter Kanal
		g = Mathf.Abs(Virusfarbe.g - Farbe.g); //--grüner Kanal
		b = Mathf.Abs(Virusfarbe.b - Farbe.b); //--blauer kanal
		if ((r + g + b) <= genauigkeit) { //wenn die Farbe des Virus genau genug der "Farbe" entspricht -> reguläres Material...
			Organ.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.clear);
		}
			else{
			Organ.GetComponent<Renderer>().material.SetColor("_EmissionColor", Farbe);//...wenn nicht -> Leuchten in der "Farbe(TM)"
			}
		if (countdown <= 0) {
			geschafft = true;
			StartCoroutine (infiziert());//startet den IENumerator (siehe unten)
		}
		if (geschafft == true){
			Organ.transform.localScale = Vector3.Lerp (Organ.transform.localScale,new Vector3(0,0,0),Time.deltaTime);//Organ schrumpft
		}
	}

	IEnumerator infiziert (){
		Organ.transform.GetChild (0).gameObject.SetActive (true);//Partikelsystem des Organs wird angeschaltet
		Organ.transform.GetChild (0).gameObject.GetComponent<ParticleSystem> ().startColor = Farbe; //Farbe der Partikel wird durch(TM) definiert
		Organ.transform.localScale = Vector3.Lerp (Organ.transform.localScale,new Vector3(0,0,0),Time.deltaTime);
		yield return new WaitForSeconds (3);
		Organ.transform.GetChild (0).gameObject.SetActive (false);
		Destroy (Organ);//Organ wird zerstört
		transform.localScale+=Vector3.one*30;
	}
}