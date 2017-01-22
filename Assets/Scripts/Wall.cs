using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private LineRenderer lr;
    private Map map;
    private float index = 0;

    // Use this for initialization
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.numPositions = 2;

        map = GetComponentInParent<Map>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 bounds = map.getEdgeBound(map.time - Mathf.FloorToInt(index));

        Transform t = gameObject.transform;
        t.position = new Vector3(map.initialX - index, 0);
       
        Vector3[] positions = new Vector3[2] { new Vector3(0, bounds[0] + 1), new Vector3(0, bounds[1] - 1) };
        lr.SetPositions(positions);

        index += .05f; 

        if (index > 25)
        {
            Destroy(gameObject);
        }
    }
}
