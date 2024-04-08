using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    public int speed;
    private float _horizontal; 

    [Header("Salto")]
    public int speedFly;
    public float _jumpForce;
    public float _timeJump;
    public bool _activeTimeJump = false;

    [Header("Deteccion de Suelo")]
    [Min(0f)]
    public float raycastDistance;
    public LayerMask layerMask;
    public bool Gronded;
    public List<Vector2> points;

    private Animator animator;
    private Rigidbody2D _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {

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
        _horizontal = Input.GetAxis("Horizontal");
        if (_horizontal != 0)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }

        if (Gronded)
        {
            animator.SetBool("Grounded", true);
        }
        else
        {
            animator.SetBool("Grounded", false);

        }
        if (Gronded)
        {
            transform.position += new Vector3(_horizontal * speed * Time.fixedDeltaTime, 0, 0);
        }
        else
        {
            transform.position += new Vector3(_horizontal * speedFly * Time.fixedDeltaTime, 0, 0);
        }

        Flip();
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump") && Gronded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            animator.SetTrigger("Jump");
        }   
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Plataforma movil"))
        {
            transform.parent = collision.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Plataforma movil"))
        {
            transform.parent = null;
        }
    }

    private void Flip()
    {
        if (_horizontal < 0)
        {
            
            if(transform.parent != null)
            {
                transform.localScale = new Vector3(-1 / transform.parent.localScale.x, 1 / transform.parent.localScale.y, 1 / transform.parent.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        if (_horizontal > 0)
        {
            
            if (transform.parent != null)
            {
                transform.localScale = new Vector3(1 / transform.parent.localScale.x, 1 / transform.parent.localScale.y, 1 / transform.parent.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
