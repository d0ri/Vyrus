using UnityEngine;
using System.Collections;

public class Antikoerperkollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.transform.tag == "Anti") {
			transform.localScale = (transform.localScale -= new Vector3 (.1f, .1f, .1f)) * 0.9f;
			Destroy (other.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
