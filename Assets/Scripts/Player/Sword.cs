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
        if (collision.transform.CompareTag("DamageEnemy") && canAttack)
        {
            collision.GetComponent<HealthEnemy>().health--;
            collision.transform.parent.GetComponent<Enemy>().canMove = false;
        }
    }


}
