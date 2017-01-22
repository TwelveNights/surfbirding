using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatusIndicator: MonoBehaviour {

    private Map map;

	// Use this for initialization
	void Start () {
        map = GameObject.Find("Map").GetComponent<Map>();
	}
	
	// Update is called once per frame
	void Update () {
        int currentX = map.time - map.initialX * 2;
        Vector2 bounds = map.getEdgeBound(currentX);
        if (bounds[0] > gameObject.transform.position.y || bounds[1] < gameObject.transform.position.y)
        {
            SceneManager.LoadScene("GameOver");
        }
        
        else if (map.gameWon())
        {
            SceneManager.LoadScene("GameWon");
        }
	}
}
