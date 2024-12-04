using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{
    public NavMeshAgent agent;
    public float speed; 

    public GameObject Cible;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = Cible.transform.position;

        agent.SetDestination(targetPosition);
        agent.speed = speed;
    }
}
