using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBehaviour : MonoBehaviour {

	[Range (0.1f, 1.0f)]
	public float fadeSpeed = 1f;    // How fast alpha value decreases.
	public Color fadeColor = new Color (0, 0, 0, 0);

	private Material material;      // Used to store material reference.
	private Color color;            // Used to store color reference.

	// Use this for initialization
	void Start () {

		// Get reference to object's material.
		material = GetComponent <Renderer> ().material;

		// Get material's starting color value.
		color = material.color;

		AlphaFade ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// This method fades only the alpha.
	IEnumerator AlphaFade () {
		// Alpha start value.
		float alpha = 1.0f;

		// Loop until aplha is below zero (completely invisalbe)
		while (alpha > 0.0f) {
			// Reduce alpha by fadeSpeed amount.
			alpha -= fadeSpeed * Time.deltaTime;

			// Create a new color using original color RGB values combined
			// with new alpha value. We have to do this because we can't 
			// change the alpha value of the original color directly.
			material.color = new Color (color.r, color.g, color.b, alpha);

			yield return null;
		}
	}
}
