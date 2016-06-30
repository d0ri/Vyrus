using UnityEngine;
using System.Collections;

public class SpawnZellen : MonoBehaviour {

	//public GameObject Zelle;
	GameObject neueZelle;
	public int maxZellen = 100;
	public float spreadx = 3;
	public float spreadz = 3;
	public float dauer = 1f;
	float zeit;//bis eine neue Zelle erscheint in sec

	void Start(){
		zeit = dauer;
		for (int i = 0; i<maxZellen;++i){
		GameObject neueZelle = Instantiate (transform.GetChild(0).gameObject, transform.position + Vector3.up * 0.2f + new Vector3 (spreadx * Random.Range (-1f, 1f), 0, spreadz * Random.Range (-1f, 1f)), Quaternion.Euler (90, 0, 0)) as GameObject;
		neueZelle.transform.parent = this.transform;
		}
	}

	void Update (){
		if (zeit > 0) {
			zeit -= Time.deltaTime;
		}
		else {
			if (transform.childCount == 1) {
				GameObject neueZelle = Instantiate (transform.GetChild (0).gameObject, transform.position + Vector3.up * 0.2f + new Vector3 (spreadx * Random.Range (-1f, 1f), 0, spreadz * Random.Range (-1f, 1f)), Quaternion.Euler (90, 0, 0)) as GameObject;
				neueZelle.transform.parent = this.transform;
				zeit = dauer;
			}
			if (transform.childCount < maxZellen) {
				GameObject neueZelle = Instantiate (transform.GetChild(0).gameObject, transform.position + Vector3.up * 0.2f + new Vector3 (spreadx * Random.Range (-1f, 1f), 0, spreadz * Random.Range (-1f, 1f)), Quaternion.Euler (90, 0, 0)) as GameObject;
				neueZelle.transform.parent = this.transform;
				zeit = dauer;
			} else {
				zeit = dauer;
			}
		}
	}
	void OnDrawGizmos(){
		Gizmos.color = new Color(0,1,0,.2f);
		Gizmos.DrawCube (transform.position,new Vector3(spreadx*2,0.1f,spreadz*2));
		Gizmos.color = Color.green;
		Gizmos.DrawSphere (transform.position, 2);
	}
}

