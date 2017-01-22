using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private LineRenderer lr;
    private Map map;
    private float index = 0;
	private int colorEmission;
	private string shotTag;
	private Renderer rend;

    // Use this for initialization
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.numPositions = 2;

        map = GetComponentInParent<Map>();
		rend = GetComponent<Renderer>();
        Material mat = rend.material;

		int emission = Random.Range(0, 3);

		switch (emission)
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
       
		Vector3[] positions = new Vector3[2] { new Vector3 (0, bounds [0] + 1), new Vector3 (0, bounds [1] - 1) };
		lr.SetPositions (positions);

		index += .05f; 

		if (index > 25) {
			Destroy (gameObject);
		}

		GameObject[] shots = GameObject.FindGameObjectsWithTag (shotTag);
		foreach (GameObject shot in shots) {
			foreach (Transform child in shot.transform) {
				if (child.GetComponent<Renderer> ().bounds.Intersects (rend.bounds)) {
					Destroy (gameObject);
				}
			}
		}
	}
}