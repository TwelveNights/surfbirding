using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theme : MonoBehaviour
{
    private static Theme instance = null;

    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } 

        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public static Theme get()
    {
        return instance;
    }
}