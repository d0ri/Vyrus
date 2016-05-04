using UnityEngine;
using System.Collections;

public class VirusBewegung : MonoBehaviour {
	
		public float moveSpeed;
		
		// Update is called once per frame
		void Update()
		{
			float h = Input.GetAxis ("Horizontal");
			float v = Input.GetAxis ("Vertical");
			
		transform.Translate (new Vector3 (h, 0, v).normalized * Time.deltaTime * moveSpeed, Space.World); //Bugfix: Space.World ergänzt, Vektor normalisiert
			
		}
		
	}
