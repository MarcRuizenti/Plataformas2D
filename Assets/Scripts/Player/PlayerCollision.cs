using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [Header("Respawn")]
    [SerializeField] private Transform chekpoint;
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Coleccionable"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.transform.CompareTag("Respaun"))
        {
            transform.position = chekpoint.position;
        }
    }
}
