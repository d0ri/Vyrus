using UnityEngine;
using System.Collections;

public class zellenfressen : MonoBehaviour {
	public float increase = 0.1f; //Gibt an um welchen Wert der Virus wächst
	void OnTriggerEnter(Collider other){
		if (other.transform.tag == "Zelle") {
			other.transform.parent = this.transform;
			transform.localScale += new Vector3 (increase, increase, increase);
		}
	}
}
