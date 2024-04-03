using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float timeMovement;
    private float timeMovementCounter;
    public float speed;
    public Vector3 direction;
    void Start()
    {
        timeMovementCounter = timeMovement; ;
    }
    void Update()
    {
        if (timeMovementCounter <= 0)
        {
            direction *= -1;
            timeMovementCounter = timeMovement; 
        }
        else
        {
            timeMovementCounter -= Time.deltaTime;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
