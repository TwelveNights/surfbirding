﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    private int resolution = 18;
    private float[] waveForm;

    [SerializeField]
    private int amplitude = 50;
    [SerializeField]
    private bool top = false;

    private AudioSource audioSource;


    // Use this for initialization
    void Start()
    {
        audioSource = GetComponentInParent<AudioSource>();
        LineRenderer lr = GetComponent<LineRenderer>();

        resolution = audioSource.clip.frequency / resolution;

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

            Vector3 newPoint = new Vector3(i, waveForm[i] * amplitude, 0);
            points[i] = newPoint;
        }

        lr.numPositions = waveForm.Length;
        lr.SetPositions(points);
        lr.startColor = Color.cyan;
        lr.endColor = Color.cyan;
        lr.startWidth = .2f;
        lr.endWidth = .2f;
    }

    // Update is called once per frame
    void Update()
    {
        Transform t = GetComponent<Transform>();

        int current = audioSource.timeSamples / resolution * 2;
        t.position = new Vector3(-current - 9, transform.position.y, transform.position.z);
    }

    public bool withinWalls(float y)
    {
        int current = audioSource.timeSamples / resolution * 2;
        if (top)
        {
            return y < waveForm[current] * amplitude;
        }
        else
        {
            return y > waveForm[current] * amplitude;
        }
    }
}