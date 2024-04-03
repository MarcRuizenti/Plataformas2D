using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlataformMove : MonoBehaviour
{
    public float speed;
    public Transform end;
    public Transform start;
    private Vector3 direccion;

    private void Start()
    {
        direccion = end.position;
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, direccion, speed * Time.deltaTime);

        if (transform.position == end.position)
        {
            direccion = start.position;
        }
        if (transform.position == start.position)
        {
            direccion = end.position;
        }
    }
}