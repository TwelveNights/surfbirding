using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualAmmoCount : MonoBehaviour {

    public AmmoCount ammoCount;

    public int ammo;

    public int reloading = 0;

    public RectTransform ammo1;
    public RectTransform ammo2;


	// Use this for initialization
	void Start () {
        ammo1 = GetComponent<RectTransform> ();
        ammo = ammoCount.ammunition;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0) && reloading == 0)
        {
            reloading++;
        }
	}
}
