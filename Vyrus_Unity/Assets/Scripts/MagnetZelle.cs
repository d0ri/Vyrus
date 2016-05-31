using UnityEngine;
using System.Collections;

public class MagnetZelle : MonoBehaviour {

	public GameObject Virus; 



	// Update is called once per frame
	void Update () {

		if (Virus.GetComponent<MagnetVirus> ().nag == true) {

			transform.position = Vector3.Lerp(transform.position,Virus.transform.position,Time.deltaTime*0.5f);}


	}
}
