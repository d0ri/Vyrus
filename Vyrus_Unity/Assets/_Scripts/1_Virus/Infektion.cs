using UnityEngine;
using System.Collections;

public class Infektion : MonoBehaviour
{

    public GameObject Organ;// welches Organ soll infiziert werden
    public Color Farbe = Color.green; // mit welcher Farbe soll das Organ infiziert werden; kann im Inspector eingestellt werden.
    public bool geschafft = false; //ist true wenn das Organ infiziert wurde
    public float genauigkeit; //wie genau muss die Farbe des Virus der "Farbe" entsprechen 0 = exakt die "Farbe muss erreicht werden", 3 = jede Farbe funktioniert
    Color Virusfarbe;
	float r=1; 
	float g=1; 
	float b=1; //drei floats für roten, grünen und blauen kanal;
    float countdown;
    public float dauer = 1.0f;//wie lange muss der Virus das Organ berühren um zu infizieren?
	//GameObject Musik;//Das Hintergrundmusik-Object aus der Hierarchy
	public AudioClip[] sounds;//beinhaltet die sounds 0(Sterben), 1(Infizierbar) und 2(Während der Infektion)
    public Texture InfNo;//für die Minimap
    public Texture InfYes;//für die Minimap
	//public bool UseClear = false;
	//public Color clearColor;//hauptsächlich als Bugfix für die Knochen. legt die Farbe fest die die Organe im "nicht markierten" Zustand haben
	AudioSource audio;

    // Use this for initialization
    void Start() {
		
		//if (UseClear == false) {
		//	clearColor = Color.clear;
		//}
		//Musik = GameObject.FindGameObjectWithTag ("Hintergrundmusik");//Hintergrundmusik wird per Tag gesucht
        countdown = dauer;
		audio = Organ.GetComponent<AudioSource> ();//Die AudioSource des Organs
		audio.volume = .15f;
		audio.Stop();

    }

    void OnTriggerStay(Collider other){//countdown und particle an
        if (other.tag == Organ.tag)
        {
            if ((r + g + b) <= genauigkeit)//Infektion
            {
                countdown -= Time.deltaTime;
                transform.GetChild(2).gameObject.SetActive(true);//schaltet InfektionsPartikel des Virus AN
                transform.GetChild(2).gameObject.GetComponent<ParticleSystem>().startColor = Farbe; //Partikelfarbe = "Farbe(TM)"
                Organ.transform.localScale = Vector3.Lerp(Organ.transform.localScale, new Vector3(0, 0, 0), Time.deltaTime / 30);//Organ schrumpft
                transform.localScale += Vector3.one * Time.deltaTime * 7f;
	
				audio.clip = sounds [2];//Infizieren
				audio.volume = 1;//volle lautstaerke
				if (audio.isPlaying == false) {
					audio.Play ();
				}
            }
        }
    }
    void OnTriggerExit(Collider other) {//particle aus countdown zurücksetzen
        if (other.tag == Organ.tag) {
            transform.GetChild(2).gameObject.SetActive(false);//schaltet InfektionsPartikel des Virus AUS

			audio.Stop ();
        }
    }
		
    void Update()
    {
        Virusfarbe = GameObject.FindGameObjectWithTag("Player").GetComponent<Renderer>().material.GetColor("_SpecColor");
        r = Mathf.Abs(Virusfarbe.r - Farbe.r); //berechnet Farbunterschied roter Kanal
        g = Mathf.Abs(Virusfarbe.g - Farbe.g); //--grüner Kanal
        b = Mathf.Abs(Virusfarbe.b - Farbe.b); //--blauer kanal
        if ((r + g + b) <= genauigkeit) { //wenn die Farbe des Virus genau genug der "Farbe" entspricht -> reguläres Material... !!!INFIZIERBAR!!!
			Organ.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.clear);
            Organ.transform.GetChild(1).GetComponent<Renderer>().material.mainTexture = InfYes;//MINIMAP
            Organ.transform.GetChild(1).GetComponent<Renderer>().material.color = Color.green;//MINIMAP


			if (audio.clip != sounds[2]) {
				audio.volume = .15f;//  lautstärke*.15, da sonst zu laut
				audio.clip=sounds[1];
				if (audio.isPlaying == false) {
					audio.Play ();
				}
			}
        }
        else {
            Organ.GetComponent<Renderer>().material.SetColor("_EmissionColor", Farbe);//...wenn nicht -> Leuchten in der "Farbe(TM)" !!!NICHT INFIZIERBAR!!!
            Organ.transform.GetChild(1).GetComponent<Renderer>().material.mainTexture = InfNo;//MINIMAP
            Organ.transform.GetChild(1).GetComponent<Renderer>().material.color = Color.red;//MINIMAP

			audio.Stop ();
        }
        if (countdown <= 0)
        {
            geschafft = true;
            StartCoroutine(infiziert());//startet den IENumerator (siehe unten)
		
        }
        if (geschafft == true){
            Organ.transform.localScale = Vector3.Lerp(Organ.transform.localScale, new Vector3(0, 0, 0), Time.deltaTime);//Organ schrumpft

        }
        //MinimapOrgan:
        Organ.transform.GetChild(2).GetComponent<Renderer>().material.color = Farbe;
		Organ.transform.GetChild(2).GetComponent<Renderer>().material.SetColor("_EmissionColor", Farbe);
    }

    IEnumerator infiziert() {
		audio.Stop ();

        Organ.transform.GetChild(0).gameObject.SetActive(true);//Partikelsystem des Organs wird angeschaltet
        Organ.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().startColor = Farbe; //Farbe der Partikel wird durch(TM) definiert
        Organ.transform.localScale = Vector3.Lerp(Organ.transform.localScale, Vector3.zero, Time.deltaTime);
        yield return new WaitForSeconds(3);
        Organ.transform.GetChild(0).gameObject.SetActive(false);
        Organ.transform.position -= new Vector3(0, 1, 0);
        yield return new WaitForSeconds(1);
        Organ.SetActive(false);
		audio.Stop ();

		//enabled = false;
    }
}