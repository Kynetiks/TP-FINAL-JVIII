using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tower_ : MonoBehaviour
{

    public GameObject core;

    public GameObject gun;
    public float turningSpeed = 10;
    public float angleTurningAccuracy = 80;

    private List<GameObject> enemiesInRange = new List<GameObject>();

    private GameObject currentTarget;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("enemy"))
        {
            enemiesInRange.Add(col.gameObject);
            Debug.Log("test");
            UpdateTarget();
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("enemy"))
        {
            enemiesInRange.Remove(col.gameObject);
            currentTarget = null;
            UpdateTarget();
        }
    }

    private void UpdateTarget()
    {
        if (currentTarget != null) {
            return;
        }


        GameObject closestEnemy = null;
        float closestDistance = float.MaxValue;

        foreach (GameObject enemy in enemiesInRange)
        {
            if (enemy == null) { return; }
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            Debug.Log("test: "+ distanceToEnemy);
            if (distanceToEnemy < closestDistance) {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy;
                Debug.Log("en collision");
            }
        }
        if (closestEnemy != null) {
            currentTarget = closestEnemy;
        }
        else {
            currentTarget = null;
        }
    }


    private void Update()
    {
        if (currentTarget != null) {
            Vector3 aimAt = new Vector3(currentTarget.transform.position.x, core.transform.position.y, currentTarget.transform.position.z);
            float distToTarget = Vector3.Distance(aimAt, gun.transform.position);
            
            Vector3 relativeTargetPosition = gun.transform.position + (gun.transform.forward * distToTarget);

            relativeTargetPosition = new Vector3(relativeTargetPosition.x, currentTarget.transform.position.y, relativeTargetPosition.z);

            gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, Quaternion.LookRotation(relativeTargetPosition - gun.transform.position), Time.deltaTime * turningSpeed);
            core.transform.rotation = Quaternion.Slerp(core.transform.rotation, Quaternion.LookRotation(aimAt - core.transform.position), Time.deltaTime * turningSpeed);

            Vector3 directionToTarget = currentTarget.transform.position - gun.transform.position;

            if (Vector3.Angle(directionToTarget, gun.transform.forward) < angleTurningAccuracy)
            {
                Fire();
            }
        }
    }

    private void Fire() {
        Debug.Log("Firing at enemies");

    }
}

