using UnityEngine;
using System.Collections;

public class zellenfressen : MonoBehaviour {
	public float wt =10.0f;// gibt an um wieviel der Virus wächst

	void OnTriggerEnter(Collider other){
		if (other.transform.tag == "Zelle") {
			other.transform.parent = this.transform;
			transform.localScale += new Vector3 (wt, wt, wt);
		}
	}
}