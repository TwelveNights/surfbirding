using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour {

    public GameObject wall;

	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {
        if (Random.value >= .99)
        {
            GameObject newWall = Instantiate(wall, new Vector3(0, 0, 0), Quaternion.identity);
        }
	}
}
