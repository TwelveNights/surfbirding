using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour {

    public float[] waveForm;
    public float width = .5f;

    private Map map;
    private LineRenderer lr;

    // Use this for initialization
    void Start()
    {
        map = GetComponentInParent<Map>();
        lr = GetComponent<LineRenderer>();

        AudioSource audioSource = map.audioSource;

        int resolution = map.resolution;

        float[] samples = new float[audioSource.clip.samples * audioSource.clip.channels];

        audioSource.clip.GetData(samples, 0);
        waveForm = new float[(samples.Length / resolution)];

        Vector3[] points = new Vector3[waveForm.Length];
   
        for (int i = 0; i < waveForm.Length; i++)
        {
            waveForm[i] = 0;

            for (int ii = 0; ii < resolution; ii++)
            {
                waveForm[i] += Mathf.Abs(samples[(i * resolution) + ii]);
            }

            waveForm[i] /= resolution;

            Vector3 newPoint = new Vector3(i, waveForm[i] * map.amplitude, 0);
            points[i] = newPoint;
        }

        lr.startColor = lr.endColor = map.color;
        lr.startWidth = lr.endWidth = width;
        lr.numPositions = waveForm.Length;
        lr.SetPositions(points);
    }

    // Update is called once per frame
    void Update()
    {
        lr.startColor = lr.endColor = map.color;
    }
}
