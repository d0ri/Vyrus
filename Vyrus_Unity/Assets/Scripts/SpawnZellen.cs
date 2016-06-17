using UnityEngine;
using System.Collections;

public class SpawnZellen : MonoBehaviour {

	public GameObject Zelle;
	public int maxZellen = 100;
	public float spread = 3;

	void Update (){
		if(GameObject.FindGameObjectsWithTag("Zelle").Length<maxZellen){
			Instantiate (Zelle, transform.position + Vector3.up * 0.2f + new Vector3 (spread * Random.Range (-1f, 1f), 0, spread * Random.Range (-1f, 1f)), Quaternion.identity);
		}
	}
}

