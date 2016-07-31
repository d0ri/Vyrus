using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Lebensanzeige : MonoBehaviour {

	public Image lebensbalken;
	float leben;
	float scale;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		scale = GameObject.FindGameObjectWithTag ("Player").transform.transform.localScale.x;
		lebensbalken.fillAmount = ((scale-40) /70.0f);
		if (scale <= 60) {
			lebensbalken.color = Color.red;
		} else {
			if (scale <= 80) {
				lebensbalken.color = Color.yellow;
			} else {
				lebensbalken.color = Color.green;
			}
		}
	}
}
