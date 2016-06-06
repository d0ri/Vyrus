using UnityEngine;
using System.Collections;
using System;

public class MagnetZelle : MonoBehaviour {
	//public GameObject Musik; Sinn? (alex)
	public AudioClip MagnetSound;

    GameObject Virus;

    void Start()
    {
        Virus = GameObject.FindGameObjectWithTag("Player");
		//Musik.SetActive (false); (Sinn?)
    }

    // Update is called once per frame
    void Update()
	{

		if (Virus.GetComponent<MagnetVirus> ().nag == true) {
			if (Vector3.Distance (Virus.transform.position, transform.position) <= 30.0f) {// Syntax korrigiert(alex)
				transform.position = Vector3.Lerp (transform.position, Virus.transform.position, Time.deltaTime * 2f);//2f(alex)
				AudioSource.PlayClipAtPoint (MagnetSound, transform.position);
			}
		}
	}

	//redundant (alex)
//    private float Distance(Vector3 vector3)
//		
//    {
//        throw new NotImplementedException();
//    }
}
	