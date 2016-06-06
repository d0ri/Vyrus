using UnityEngine;
using System.Collections;
using System;

public class MagnetZelle : MonoBehaviour {
	public GameObject Musik;
	public AudioClip MagnetSound;

    GameObject Virus;

    void Start()
    {
        Virus = GameObject.FindGameObjectWithTag("Player");
		Musik.SetActive (false);
    }

    // Update is called once per frame
    void Update()
	{

		if (Virus.GetComponent<MagnetVirus> ().nag == true) {
			if (Distance (Virus.transform.position - transform.position) <= 100.0f) {// Subtrahenden vertauscht (alex)
				transform.position = Vector3.Lerp (transform.position, Virus.transform.position, Time.deltaTime * 1f);//1f
				AudioSource.PlayClipAtPoint (MagnetSound, transform.position);
			}
		}
	}

    private float Distance(Vector3 vector3)
		
    {
        throw new NotImplementedException();
    }
}
	