using UnityEngine;
using System.Collections;
using UnityEngine.UI;    // Weil Vorspann auf UI gezeigt wird
using UnityEngine.SceneManagement;// SceneManagement ersetzt Application.LoadLevel

[RequireComponent (typeof(AudioSource))]  //AudioQuelle als Voraussetzung, dass man sie nicht vergisst

public class Vorspann : MonoBehaviour {

	public MovieTexture movie;    //Film Textur, in die man den gewünschten Film ziehen kann
	private AudioSource audio;     //AudioQuelle als private Komponente

	void Start () {
		GetComponent<RawImage>().texture = movie as MovieTexture; //dem RawImnage zeigen, dass die ausgewählte Textur als Film abgespielt werden soll
		audio = GetComponent<AudioSource>();
		audio.clip = movie.audioClip;        //das der Ton vom Film abgespielt wird
		movie.Play();               //Film wird abgespielt
		audio.Play ();              //Audio wird abgespielt
	}



	void Update () {

		if(!movie.isPlaying) Application.LoadLevel("1_Johanna"); //wenn der Vorspann nicht läuft/beendet ist/stoppt, kommt man automatisch zu Level1 
		//if(!movie.isPlaying) SceneManager.LoadScene(1);   //statt Application.LoadLevel

		if (Input.GetKeyDown (KeyCode.Space) && movie.isPlaying) {  //wenn Leertaste gedrückt wird, wenn Film läuft

			movie.Stop();                                        //stoppt der Film
		}


	}
}