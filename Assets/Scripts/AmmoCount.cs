using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AmmoCount : MonoBehaviour {
    public int ammunition;
    public int reload;
    public int maxAmmo;

	public GameObject[] colorShots;

	public GameObject birbLocation;
	public RectTransform rectTransform;
    public Text text;
    

	// Use this for initialization
	void Start () {
        maxAmmo = 3;
        ammunition = maxAmmo;
        reload = 2;
        text = GetComponent<Text>();
	}

    void CheckKeys()
    {
        if (Input.GetMouseButtonDown(0))
        {
			if (ammunition > 0) {
				ammunition--;
				if (ammunition == 0) {
					text.text = "0";
				} else {
                    text.text = ammunition.ToString() ;
				}
				StartCoroutine (Delay ());

				Color color = rectTransform.GetComponent<Image> ().color;
				GameObject colorShot;
				AudioSource audioSource;

				if (color == Color.blue) {
					colorShot = colorShots[0];
					audioSource = GetComponents<AudioSource>()[0];
				} else if (color == Color.green) {
					colorShot = colorShots[1];
					audioSource = GetComponents<AudioSource>()[1];
				} else if (color == Color.red) {
					colorShot = colorShots[2];
					audioSource = GetComponents<AudioSource>()[2];
				} else {
					return;
				}

				GameObject newShot = Instantiate (colorShot, birbLocation.transform.position
					, Quaternion.identity) as GameObject;
				Object.Destroy (newShot, 0.9f);

				audioSource.Play ();
            }
        }
       
    }

    IEnumerator Delay()
    {
//        print(Time.time);
        yield return new WaitForSecondsRealtime(reload);

        ammunition++;

        text.text = ammunition.ToString();


 //       print(Time.time);
    }
	
	// Update is called once per frame
	void Update () {
        CheckKeys();


    }
}
