using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] GameObject vfxSpawn;
    [SerializeField] GameObject vfxDeath;
    private Animator animator;  // R�f�rence � l'Animator de l'ennemi
    //private bool NearTarget = false;  // Indicateur si l'ennemi est � port�e du cristal

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
        // V�rifie si l'objet avec lequel il entre en collision est un ennemi
        if (other.CompareTag("Crystal"))
        {

            Debug.Log("Crystal rep�r�");
            if (animator != null)
            {
                animator.SetBool("NearTarget", true);
            }

        }
    }
    private void Start()
    {
        animator = GetComponent<Animator>();  // R�cup�re l'Animator attach� � l'ennemi
        if (animator == null)
        {
            Debug.LogError("L'Animator de l'ennemi n'a pas �t� trouv� !");
        }
    }

}
