﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wall : MonoBehaviour
{
    private LineRenderer lr;
    private Map map;

	private Renderer rend;
	private Renderer birbRenderer;

    private float index = 0;
	private string shotTag;

    // Use this for initialization
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.numPositions = 2;

        map = GetComponentInParent<Map>();
		rend = GetComponent<Renderer>();

        Material mat = rend.material;
		birbRenderer = GameObject.Find ("Birb").GetComponentsInChildren<Renderer>()[0];

		switch (Random.Range(0, 3))
        {
		case 0:
			mat.SetColor ("_EmissionColor", Color.red);
			shotTag = "RedShot";
            break;
		case 1:
			mat.SetColor ("_EmissionColor", Color.green);
			shotTag = "GreenShot";
            break;
		case 2:
			mat.SetColor ("_EmissionColor", Color.blue);
			shotTag = "BlueShot";
            break;
        }
    }

    // Update is called once per frame
    void Update()
	{
		Vector2 bounds = map.getEdgeBound (map.time - Mathf.FloorToInt (index));

		Transform t = gameObject.transform;
		t.position = new Vector3 (map.initialX - index, 0);
       
		Vector3[] positions = new Vector3[2] { new Vector3 (0, bounds [0] + .25f), new Vector3 (0, bounds [1] - .25f) };
		lr.SetPositions (positions);

		index += .05f; 

		if (index > 25) {
			Destroy (gameObject);
		}

		// Destroy wall if correct color shot hits wall
		GameObject[] shots = GameObject.FindGameObjectsWithTag (shotTag);
		foreach (GameObject shot in shots) {
			foreach (Transform child in shot.transform) {
				if (child.GetComponent<Renderer> ().bounds.Intersects (rend.bounds)) {
					Destroy (gameObject);
				}
			}
		}

		// Game over if bird touches wall
		if (birbRenderer.bounds.Intersects (rend.bounds)) {
			SceneManager.LoadScene ("GameOver");
		}
	}
}