using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

	public GameObject[] Antikoerper;//Liste der Antikoerper, kann im Inspector definiert werden
	public int maxAnti = 1;//maximale Anzahl an Antikoerpern (ganze Zahlen verwenden), kann im Inspector eingestellt werden

	void OnTriggerEnter(Collider other){//wenn TriggerEnter...
		if (other.tag == "Player" && GameObject.FindGameObjectsWithTag ("Anti").Length<maxAnti) {//...überprüft ob es sich um den Virus handelt und weniger Antikoerper als maxAnti vorhanden sind
			Instantiate (Antikoerper[(Random.Range(0,3))], transform.position+Vector3.up, Quaternion.identity);//wählt einen der Antikoerper aus der Liste und instanziiert ihn an der Position des SpawnPoint
		}
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.magenta;
		Gizmos.DrawSphere (transform.position,3);
	}
}
