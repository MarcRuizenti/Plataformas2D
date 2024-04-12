using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoDeFondo : MonoBehaviour
{

    public static SonidoDeFondo Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
