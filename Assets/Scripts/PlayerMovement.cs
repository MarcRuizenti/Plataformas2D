using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;

[ExecuteAlways]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    public int speed;

    [Header("Deteccion de Suelo")]
    [Min(0f)]
    public float raycastDistance;
    public LayerMask layerMask;
    public bool Gronded;
    public List<Vector2> points;

    private Rigidbody2D _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        transform.position += new Vector3( Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime, 0, 0);

        Gronded = false;
        foreach (Vector2 p in points)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + (Vector3)p, -Vector2.up, raycastDistance, layerMask);
            Debug.DrawRay(transform.position + (Vector3)p, -Vector2.up * raycastDistance, Color.red);
            Debug.DrawRay(transform.position + (Vector3)p, -Vector2.up * hit.distance, Color.green);
            if (hit.collider)
            {
                Gronded = true;
            }

        }

    }
    void Update()
    {
       
    }
}
