using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AmmoCount : MonoBehaviour {
    public int ammunition;
    public int reload;

	public GameObject shot;
	public GameObject birbLocation;
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

				GameObject newShot = Instantiate (shot, birbLocation.transform.position
					+ new Vector3(-8, 0, 0), Quaternion.identity) as GameObject;
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
