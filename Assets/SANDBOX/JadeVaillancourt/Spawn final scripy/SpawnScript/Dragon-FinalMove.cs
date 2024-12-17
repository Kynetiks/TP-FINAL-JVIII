using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonVole : MonoBehaviour
{
    public float speed = 5f; 
    private Transform target; 
    private Rigidbody rb; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();


        rb.useGravity = false;


        GameObject crystal = GameObject.FindGameObjectWithTag("Crystal");

        if (crystal != null)
        {
            target = crystal.transform;
        }
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            MoveTowards();
        }
    }

    void MoveTowards()
    {

        Vector3 direction = target.position - transform.position;
        direction.Normalize(); 


        transform.position += direction * speed * Time.deltaTime;
    }
}