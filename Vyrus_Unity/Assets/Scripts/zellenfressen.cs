using UnityEngine;
using System.Collections;

public class zellenfressen : MonoBehaviour {
		void OnTriggerEnter(Collider other){
		if (other.transform.tag == "Zelle") {
			other.transform.parent = this.transform;
			transform.localScale += new Vector3 (.2f, .2f, .2f);
	}
}
}