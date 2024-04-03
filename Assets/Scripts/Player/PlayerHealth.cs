using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    void Update()
    {
        if (health <= 0)
        {
            Time.timeScale = 0;
        }
    }
}
