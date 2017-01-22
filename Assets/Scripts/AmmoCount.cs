using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AmmoCount : MonoBehaviour {
    public int ammunition;
    public int reload;

	public GameObject blueShot;
	public GameObject redShot;
	public GameObject greenShot;

	public GameObject birbLocation;
	public RectTransform rectTransform;
    public Text text;
    

	// Use this for initialization
	void Start () {
        ammunition = 2;
        reload = 2;
        text = GetComponent<Text>();
	}

    void CheckKeys()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ammunition > 0)
            {
                ammunition--;
                if (ammunition == 1)
                {
                    text.text = "1";
                } else if (ammunition == 0)
                {
                    text.text = "0";
                }
                StartCoroutine(Delay());

				Color color = rectTransform.GetComponent<Image> ().color;
				GameObject newShot;
				if (color == Color.blue) {
					newShot = Instantiate (blueShot, birbLocation.transform.position
					+ new Vector3 (-8, 0, 0), Quaternion.identity) as GameObject;
				} else if (color == Color.red) {
					newShot = Instantiate (redShot, birbLocation.transform.position
					+ new Vector3 (-8, 0, 0), Quaternion.identity) as GameObject;
				} else if (color == Color.green) {
					newShot = Instantiate (greenShot, birbLocation.transform.position
					+ new Vector3 (-8, 0, 0), Quaternion.identity) as GameObject;
				} else {
					return;
				}
				Object.Destroy (newShot, 0.5f);
            }
        }
       
    }

    IEnumerator Delay()
    {
        print(Time.time);
        yield return new WaitForSecondsRealtime(reload);

        ammunition++;

        if (ammunition == 1)
        {
            text.text = "1";
        }
        else if (ammunition == 2)
        {
            text.text = "2";
        }
        print(Time.time);
    }
	
	// Update is called once per frame
	void Update () {
        CheckKeys();


    }
}
