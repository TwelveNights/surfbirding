using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMovement : MonoBehaviour {

	private static int MAX_AMPLITUDE = 5;
	private static int MIN_AMPLITUDE = 1;
	private static int MAX_FREQUENCY = 5;
	private static int MIN_FREQUENCY = 1;

	private int trueFreq;
	private int trueAmpl;

	private int interFreq;
	private int interAmpl;

	private bool isGoingUp;

	// Use this for initialization
	void Start () {
		trueFreq = 1;
		trueAmpl = 1;

		interFreq = 1;
		interAmpl = 1;

		isGoingUp = true;
	}

	// Update is called once per frame
	void Update () {
		Vector3 direction = (isGoingUp) ? Vector3.up : Vector3.down;

		if (Mathf.Abs (transform.position.y) > trueAmpl) {
			transform.position = direction * trueAmpl;
			isGoingUp = !isGoingUp;
			return;
		}

		if (Mathf.Abs (transform.position.y) < MIN_AMPLITUDE) {
			trueAmpl = interAmpl;
			trueFreq = interFreq;
		}

		if (Input.GetKeyDown (KeyCode.UpArrow) && interAmpl < MAX_AMPLITUDE) {
			interAmpl += 1;
		} else if (Input.GetKeyDown (KeyCode.DownArrow) && interAmpl > MIN_AMPLITUDE) {
			interAmpl -= 1;
		} else if (Input.GetKeyDown (KeyCode.RightArrow) && interFreq < MAX_FREQUENCY) {
			interFreq += 1;
		} else if (Input.GetKeyDown (KeyCode.LeftArrow) && interFreq > MIN_FREQUENCY) {
			interFreq -= 1;
		}

		transform.position += direction * trueAmpl * trueFreq * Time.deltaTime;
	}
//		float mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
//		float sinWave = Mathf.Sin (Time.time * trueFreq) * trueAmpl;
//
//		transform.position = new Vector3 (transform.position.x, sinWave - mousePos, transform.position.z);


//		transform.position = transform.up * sinWave;

//		if (Input.GetKey (KeyCode.UpArrow) && interAmpl < MAX_AMPLITUDE) {
//			interAmpl += 0.25f;
//		} else if (Input.GetKey (KeyCode.DownArrow) && interAmpl > MIN_AMPLITUDE) {
//			interAmpl -= 0.25f;
//		} else if (Input.GetKey (KeyCode.RightArrow) && interFreq < MAX_FREQUENCY) {
//			interFreq += 0.25f;
//		} else if (Input.GetKey (KeyCode.LeftArrow) && interFreq > MIN_FREQUENCY) {
//			interFreq -= 0.25f;
//		}
//
//		if ((isGoingUp && transform.position.y > 0.1f) ||
//			(!isGoingUp && transform.position.y < 0.1f)) {
//			trueFreq = interFreq;
//			trueAmpl = interAmpl;
//		}
//
//		if (Mathf.Abs (transform.position.y) > trueAmpl) {
//			isGoingUp = !isGoingUp;
//			trueFreq = interFreq;
//			trueAmpl = interAmpl;
//		}
//
//		Vector3 direction = (isGoingUp) ? Vector3.up : Vector3.down;
//		transform.position = direction * Mathf.Sin (elapsedTime * trueFreq) * trueAmpl;
//
//		elapsedTime += Time.deltaTime;
//
}
