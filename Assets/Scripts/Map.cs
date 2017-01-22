using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    public GameObject edge;
    private GameObject top;
    private GameObject bot;

    public Color color = Color.cyan;
    public int amplitude; // 16
    public int resolution; // 16

    public int yHeight = 0;
    public int tunnelWidth = 5;
    public int initialX = 14; // 14

    public int time = 0;

    public AudioSource audioSource;

    // Use this for initialization
    void Start () {

        audioSource = GetComponent<AudioSource>();
        Vector3 pos = gameObject.transform.position;

        top = Instantiate(edge, new Vector3(pos.x, pos.y + yHeight), Quaternion.identity, gameObject.transform);
        bot = Instantiate(edge, new Vector3(pos.x, pos.y + yHeight - tunnelWidth), Quaternion.identity, gameObject.transform);
 
        resolution = audioSource.clip.frequency / resolution;
    }

    // Update is called once per frame
    void Update () {
        Transform t = gameObject.transform;

        time = audioSource.timeSamples / resolution * 2;
        t.position = new Vector3(initialX - time, transform.position.y);
    }

    public Vector2 getEdgeBound(int curr)
    {
        Edge tEdge = top.GetComponent<Edge>();
        Edge bEdge = bot.GetComponent<Edge>();

        if (curr < 0 || curr > tEdge.waveForm.Length)
        {
            return new Vector2(float.MinValue, float.MaxValue);
        }

        return new Vector2(tEdge.waveForm[curr] * amplitude - tunnelWidth + yHeight, bEdge.waveForm[curr] * amplitude + yHeight);
    }
}
    