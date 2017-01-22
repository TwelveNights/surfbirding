using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteC : MonoBehaviour {
    public Image image;

    public ChangeColor changeColor;
    public float duration;
    float t = 0;

    // Use this for initialization
    void Start()
    {
        changeColor = GetComponent<ChangeColor>();
        duration = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            image.color = Color.white;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            image.color = Color.Lerp(image.color, Color.clear, t);
        }
        if (t < 1)
        {
            t += duration;
        }
    }
}
