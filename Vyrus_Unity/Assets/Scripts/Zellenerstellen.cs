using UnityEngine;
using System.Collections;

public class Zellenerstellen : MonoBehaviour {
	GameObject[] Zellen;
	public float count;
	float startcount;
	public GameObject Zelle;
	void Start () {
		count = Zellen.Length;
	}

	// Update is called once per frame
	void Update () {
		Zellen = GameObject.FindGameObjectsWithTag("Zelle");
		count = Zellen.Length;
		if (count <= 400f) {
			Instantiate (Zelle, new Vector3 (Random.Range(-160, 160), .1f, Random.Range(-190, 90)), Quaternion.identity);
		}
	}
}
