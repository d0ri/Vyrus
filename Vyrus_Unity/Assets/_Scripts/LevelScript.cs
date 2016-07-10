using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour {

	public GameObject[] Organe;
	bool beendet = false;
	public int LevelInt = 1;

	void Update () {
		for (int i = 0; i < Organe.Length; i++) {
			if (!Organe[i].activeInHierarchy) {
				beendet = true;
			} else {
				beendet = false;
			}
		}
		if (beendet == true) {
			Debug.Log("beendet");
			SceneManager.LoadScene (LevelInt);
		}
	}	
}