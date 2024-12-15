using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    [SerializeField] GameObject vfx;
    public void Spawn()
    {
        GameObject clone = Instantiate(vfx);
        clone.transform.position = gameObject.transform.position;

    }
}
