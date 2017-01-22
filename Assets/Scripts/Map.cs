using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    public GameObject edge;
    private GameObject top;
    private GameObject bot;

    public int amplitude = 50;
    public Color color = Color.cyan;
    public int resolution = 18;
    public float width = .1f;
    public int tunnelWidth = 5;

    public int current = 0;

    public AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        Vector3 pos = gameObject.transform.position;

        top = Instantiate(edge, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
        top.transform.parent = gameObject.transform;

        bot = Instantiate(edge, new Vector3(pos.x, pos.y - tunnelWidth, pos.z), Quaternion.identity);
        bot.transform.parent = gameObject.transform;

        resolution = audioSource.clip.frequency / resolution;
    }

    // Update is called once per frame
    void Update () {
        Transform t = gameObject.transform;

        current = audioSource.timeSamples / resolution * 2;
        t.position = new Vector3(-current, transform.position.y, transform.position.z);
    }

    public Vector2 getEdgeBound()
    {
        Edge tEdge = top.GetComponent<Edge>();
        Edge bEdge = bot.GetComponent<Edge>();

        return new Vector2(tEdge.waveForm[current] * amplitude - tunnelWidth, bEdge.waveForm[current] * amplitude);
    }
}
    