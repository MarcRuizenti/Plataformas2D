using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public bool canAttack;
    void Start()
    {
        canAttack = true;
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy") && canAttack)
        {
            collision.GetComponent<HealthEnemy>().health--;
            collision.GetComponent<Enemy>().canMove = false;
        }
    }


}
