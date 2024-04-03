using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [Header("Respawn")]
    [SerializeField] private Transform chekpoint;

    [Header("Damage")]
    public float regenTime;
    public float regenTimeCounter;
    public bool regen;

    private void Start()
    {
        regen = false;
        regenTimeCounter = regenTime;
    }
    void Update()
    {
        if (regen)
        {
            if (regenTimeCounter <= 0)
            {
                gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
                regen = false;
                regenTimeCounter = regenTime;
            }
            else
            {
                regenTimeCounter -= Time.deltaTime;
                gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Coleccionable"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.transform.CompareTag("Respaun"))
        {
            transform.position = chekpoint.position;
        }
        else if (collision.transform.CompareTag("Enemy") && !regen)
        {
            Debug.Log("Au");
            gameObject.GetComponent<PlayerHealth>().health--;
            regen = true;
        }
    }
}
