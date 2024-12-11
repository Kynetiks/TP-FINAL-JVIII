using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    protected TurretState state;

    protected void Start()
    {
        ChangeState(new IdleState());
    }

    public void ChangeState(TurretState state)
    {
        this.state = state;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        state.OnTriggerEnter(other);


    }

    private void OnTriggerExit(Collider other)
    {

    }

}

