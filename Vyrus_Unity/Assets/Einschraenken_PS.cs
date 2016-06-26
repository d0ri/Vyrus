using UnityEngine;
using System.Collections;

public class Einschraenken_PS : MonoBehaviour {

	GameObject virus;
	public float langsamkeit = 1f;
	public float dauer = 3f;
	//public AudioClip Bremsgeräusch;

	void start(){
		virus = GameObject.FindGameObjectWithTag ("Player");
	}


	void OnParticleCollision(GameObject other){
		if (other.tag == "Desinfektionsspray") {
			//Debug.Log ("COLLISSION");
			StartCoroutine (Freeze());
		}
	}

	IEnumerator Freeze ()
	{
		virus = GameObject.FindGameObjectWithTag ("Player");//bugfix, definiert Virus
		virus.GetComponent<VirusBewegung> ().moveSpeed /= langsamkeit;
		yield return new WaitForSeconds (dauer);
		virus.GetComponent<VirusBewegung>().moveSpeed *= langsamkeit;
		//AudioSource.PlayClipAtPoint (Bremsgeräusch, transform.position);
	}
}
