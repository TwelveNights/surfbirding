using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualAmmoCount : MonoBehaviour {

    public AmmoCount ammoCount;

    public int ammo;

	// Use this for initialization
	void Start () {
        ammo = ammoCount.ammunition;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
