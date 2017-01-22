using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusoidalMovement : MonoBehaviour {

	// Constants defining Amplitude and Frequency
	private static float AMPLITUDE_STEP = 0.001f;
	private static float START_AMPLITUDE = 3;
	private static float FREQUENCY_STEP = 0.05f;
	private static float START_FREQUENCY = 6;

	private float currentAmplitude;
	private float currentFrequency;

	// Use this for initialization
	void Start () {
		currentAmplitude = START_AMPLITUDE;
		currentFrequency = START_FREQUENCY;
	}

	// Update is called once per frame
	void Update () {
		float currMousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition).y;
		float increment = Mathf.Sin (Time.time) * currentAmplitude + currMousePos;
		transform.position = new Vector3(-8 , increment);

		currentAmplitude += AMPLITUDE_STEP;
		currentFrequency += FREQUENCY_STEP;
	}

}
