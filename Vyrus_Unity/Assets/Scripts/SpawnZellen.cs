using UnityEngine;
using System.Collections;

public class SpawnZellen : MonoBehaviour {

	public GameObject Zelle;
	GameObject neueZelle;
	public int maxZellen = 100;
	public float spread = 3;

	void Update (){
		if(transform.childCount<maxZellen){
			GameObject neueZelle = Instantiate (Zelle, transform.position + Vector3.up * 0.2f + new Vector3 (spread * Random.Range (-1f, 1f), 0, spread * Random.Range (-1f, 1f)), Quaternion.Euler(90, 0, 0)) as GameObject;
			neueZelle.transform.parent = this.transform;
		}
	}
	void OnDrawGizmos(){
		Gizmos.color = new Color(0,.5f,0,.2f);
		Gizmos.DrawCube (transform.position,new Vector3(spread*2,0.1f,spread*2));
		Gizmos.color = Color.green;
		Gizmos.DrawSphere (transform.position, 2);
	}
}

