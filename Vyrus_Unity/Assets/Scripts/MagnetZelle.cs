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
			if (Distance (transform.position - Virus.transform.position) <= 10.0f) {
				transform.position = Vector3.Lerp (transform.position, Virus.transform.position, Time.deltaTime * 0.5f);
				AudioSource.PlayClipAtPoint (MagnetSound, transform.position);
			}
		}
	}

    private float Distance(Vector3 vector3)
		
    {
        throw new NotImplementedException();
    }
}
	