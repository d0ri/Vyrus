using UnityEngine;
using System.Collections;

public class KameraFolgen : MonoBehaviour {
	
	GameObject player;
	
	float pythagoras;
	Vector3 offset = new Vector3 (0, 2, 0);
	public float distance = 5f;
	public float smooth = .65f;
	
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	void Update () {
		pythagoras = distance * 100;//player.transform.localScale.x; //Berücksichtigung der Spielergröße
		offset = new Vector3 (0,pythagoras,0);
		transform.position = Vector3.Lerp (transform.position, player.transform.position + offset, smooth);
	}
}

