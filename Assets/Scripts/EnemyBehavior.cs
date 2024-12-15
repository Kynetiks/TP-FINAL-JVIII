using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] GameObject vfxSpawn;
    [SerializeField] GameObject vfxDeath;
    public void Spawn()
    {
        GameObject clone = Instantiate(vfxSpawn);
        clone.transform.position = gameObject.transform.position;

    }
    public void Death()
    {
        GameObject clone = Instantiate(vfxDeath);
        clone.transform.position = gameObject.transform.position;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet avec lequel il entre en collision est un ennemi
        if (other.CompareTag("Crystal"))
        { 
            Debug.Log("L'ennemi attaque le cristal!");
            //Enemy enemy = other.GetComponent<Enemy>();

            //enemy.NearTarget = true;
           

        }
    }
}
