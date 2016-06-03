using UnityEngine;
using System.Collections;

public class Zellenerstellen : MonoBehaviour {
	public Vector3[] Spawn = new Vector3[10]; //Punkte an denen die Zellen spawnen können
	GameObject[] Zellen;
	public float spread = 35; //Abweichung vom Spawnpunkt
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
		if (count <= 150f) {
			Instantiate (Zelle, (Spawn [(Random.Range(0,10))])+new Vector3(spread*Random.value,0,spread*Random.value), Quaternion.identity);
		}
	}
}
