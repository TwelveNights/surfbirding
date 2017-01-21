using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMovement : MonoBehaviour {

	private static float MAX_AMPLITUDE = 3f;
	private static float MIN_AMPLITUDE = 1.25f;
	private static float MAX_FREQUENCY = 5f;
	private static float MIN_FREQUENCY = 1f;

	private float frequency;
	private float amplitude;
	private bool isGoingUp;

	// Use this for initialization
	void Start () {
		frequency = 3;
		amplitude = 3;
		isGoingUp = true;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.UpArrow) && amplitude < MAX_AMPLITUDE) {
			amplitude += 0.25f;
		} else if (Input.GetKey (KeyCode.DownArrow) && amplitude > MIN_AMPLITUDE) {
			amplitude -= 0.25f;
		} else if (Input.GetKey (KeyCode.RightArrow) && frequency < MAX_FREQUENCY) {
			frequency += 0.25f;
		} else if (Input.GetKey (KeyCode.LeftArrow) && frequency > MIN_FREQUENCY) {
			frequency -= 0.25f;
		}

		if (Mathf.Abs (transform.position.y) > amplitude) {
			isGoingUp = !isGoingUp;
		}

		Vector3 direction = (isGoingUp) ? Vector3.up : Vector3.down;
		transform.position +=  direction * frequency * Time.deltaTime;
	}
}
