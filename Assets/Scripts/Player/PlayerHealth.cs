using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    void Update()
    {



    }
    public void Dead()
    {
        if (health <= 0)
        {
            Time.timeScale = 0;
        }
    }
}
