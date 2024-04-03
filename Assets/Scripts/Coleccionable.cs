using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    private GameManager gameManager;
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    void Update()
    {
        
    }
    private void OnDestroy()
    {
        gameManager.coleccion++;
        gameManager.coleccionables.Remove(gameObject);
    }
}
