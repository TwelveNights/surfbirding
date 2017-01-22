using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Image image;

    public Color colorz;

    public ChangeColor changeColor;
    public Renderer cRend;
   

//    Texture2D texture;
//    Renderer renderer;

//    GameObject rect;

    // Use this for initialization
    void Start () {
        cRend = GetComponent<Renderer>();
        changeColor = GetComponent<ChangeColor>();
        image = GetComponent<Image>();
        image.color = Color.blue;

        //        cRend.material.color = changeColor.color;
//        texture = new Texture2D(1, 1);                //texture size
//        renderer = GetComponent<Renderer>();
//        renderer.material.mainTexture = texture;
       
    }




	
	// Update is called once per frame
	void Update () {
        
        //        colorz = image.color;
       

        image.color = changeColor.color;
        //        cRend.material.color = changeColor.color;

        //        GetComponent<Renderer>().material.color = cRend.material.color;

    }
}
