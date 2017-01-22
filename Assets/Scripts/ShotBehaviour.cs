using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBehaviour : MonoBehaviour {

	private float scale = 0.0f;

	// Use this for initialization
	void Start () {
		StartCoroutine(Enlarge());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// This method fades only the alpha.
	IEnumerator Enlarge () {

		// Loop until aplha is below zero (completely invisalbe)
		while (scale < 1.0f) {
			// Reduce alpha by fadeSpeed amount.
			transform.localScale += new Vector3(1f, 1f, 0) * Time.deltaTime;
			scale += 0.01f;

			yield return null;
		}
	}
}
