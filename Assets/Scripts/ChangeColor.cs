using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {

    public Color color;

    public int pos = 0;
    
    public static Color[] colors = new Color[3];

    Color r;
    Color b;
    Color g;

    public float t = 1;

    // Use this for initialization
    void Start () {
        colors[0] = Color.blue;          //Blue
        colors[1] = Color.green;         //Green
        colors[2] = Color.red;           //Red
        color = Color.blue;
        
    }


    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            pos = 0;
//            color = Color.Lerp(color, colors[pos], t);
            color = colors[pos];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            pos = 1;
 //           color = Color.Lerp(color, colors[pos], t);
            color = colors[pos];
            //            pos = Mathf.Abs(pos % numColors);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            pos = 2;
//            color = Color.Lerp(color, colors[pos], t);
            color = colors[pos];
        }
    }

    public Color getColor()
    {
        return color;
    }
}
