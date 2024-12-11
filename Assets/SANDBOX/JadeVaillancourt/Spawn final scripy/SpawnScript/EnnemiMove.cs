using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemiMove : MonoBehaviour
{

    public NavMeshAgent agent;
    public float speed = 1;

    public GameObject crystal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 targetPosition = crystal.transform.position;
        Vector3 targetPosition = Camera.main.transform.position;

        agent.SetDestination(targetPosition);
        agent.speed = speed;
    }
}
