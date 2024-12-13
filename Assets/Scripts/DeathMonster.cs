using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMonster : MonoBehaviour
{
    [SerializeField] GameObject vfx;
    public void Death(){
        GameObject clone = Instantiate(vfx);
        clone.transform.position = gameObject.transform.position;
        Destroy(gameObject);
    }
}
