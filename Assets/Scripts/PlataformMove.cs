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
    //public float timeDesplazamiento;
    //public float timeDesplazamientoCount;

    private void Start()
    {
        //timeDesplazamientoCount = timeDesplazamiento;
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
        //if (timeDesplazamientoCount >= 0)
        //{
        //    transform.position += direccion * Time.deltaTime * speed;
        //    timeDesplazamientoCount -= Time.deltaTime;
        //}
        //else
        //{
        //    direccion *= -1;
        //    timeDesplazamientoCount = timeDesplazamiento;
        //}

    }
}