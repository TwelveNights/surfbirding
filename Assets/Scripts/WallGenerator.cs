using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour {

    public GameObject wall;
    public float probability = 0.005f;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        if (Random.value < probability)
        {
            Instantiate(wall, new Vector3(GetComponent<Map>().initialX, 0), Quaternion.identity, gameObject.transform);
        }
	}
}
