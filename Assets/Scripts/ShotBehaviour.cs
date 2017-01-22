using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(Enlarge());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	IEnumerator Enlarge () {
		while (true) {
			transform.localScale += new Vector3(0.4f, 0.4f, 0) * Time.deltaTime;
			transform.localPosition += new Vector3 (2f, 0, 0) * Time.deltaTime;

			yield return null;
		}
	}
//
//	void OnTriggerEnter2D(Collision2D collision) {
//		Collider2D other = collision.collider;
//
//		if(other.gameObject.CompareTag("Wall")) { 
//			Destroy (other.gameObject);
//		}
//	}
}
