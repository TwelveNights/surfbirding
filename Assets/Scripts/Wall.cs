using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        LineRenderer lr = GetComponent<LineRenderer>();
        Map map = GameObject.Find("Map").GetComponent<Map>();
        Vector2 timing = map.getEdgeBound();

        Transform t = gameObject.transform;
    
        Vector3 bot = lr.GetPosition(0);
        Vector3 top = lr.GetPosition(1);

        bot[1] = timing[0];
        top[1] = timing[1];

        Vector3[] positions = new Vector3[2];
        positions[0] = bot;
        positions[1] = top;

        lr.SetPositions(positions);

        if (gameObject.transform.position.x < -14)
        {
            Destroy(gameObject);
        }
    }
}
