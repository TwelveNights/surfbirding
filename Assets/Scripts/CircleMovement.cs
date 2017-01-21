using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMovement : MonoBehaviour {

	private float frequency = 5;
	private float amplitude = 5;
	private bool isGoingUp;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y > amplitude) {
			isGoingUp = false;
		} else if (transform.position.y < -1*amplitude) {
			isGoingUp = true;
		}
		
		if (isGoingUp) {
			transform.position += Vector3.up * amplitude * frequency * Time.deltaTime;
		} else {
			transform.position += Vector3.down * amplitude * frequency  * Time.deltaTime;
		}
	}
}
