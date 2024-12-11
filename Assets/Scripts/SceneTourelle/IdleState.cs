using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : TurretState
{
    public override void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            
        }
    }
}
