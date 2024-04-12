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
    public Animator animator;
    private GameManager gm;

    [Header("Sound")]
    public AudioClip hurt;
    void Start()
    {
        timeMovementCounter = timeMovement;
        canMove = true;
        moveonCounter = moveon;
        animator = GetComponent<Animator>();
        gm = FindAnyObjectByType<GameManager>();

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
                animator.SetBool("isMoveing", true);
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
            animator.SetBool("isMoveing", false);
        }
    }

    public void Dead()
    {
        if (transform.GetChild(1).GetComponent<HealthEnemy>().health <= 0)
        {
            gm.enemies.Remove(gameObject);
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

    public void PlayHurt()
    {
        SoundManager.Instance.EjecutarAudio(hurt);
    }
}
