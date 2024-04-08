using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float timeMovement;
    private float timeMovementCounter;
    public float speed;
    public Vector3 direction;
    public bool canMove;
    public float moveon;
    private float moveonCounter;
    void Start()
    {
        timeMovementCounter = timeMovement;
        canMove = true;
        moveonCounter = moveon;

    }
    void Update()
    {
        if (canMove)
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
            Flip();
        }
        else
        {
            if (moveonCounter <= 0)
            {
                canMove = true;
                moveonCounter = moveon;
            }
            else
            {
                moveonCounter -= Time.deltaTime;
            }
        }
        if (transform.GetChild(1).GetComponent<HealthEnemy>().health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Flip()
    {
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (direction.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
