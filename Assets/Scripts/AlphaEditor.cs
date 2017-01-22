using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class AlphaEditor : MonoBehaviour {
    
    Image image;
    public float alphaValue;

    void Start()
    {
        image = GetComponent<Image>();

        Color c = image.color;
        c.a = alphaValue;
        image.color = c;
    }

}
