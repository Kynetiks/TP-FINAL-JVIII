using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] GameObject vfxSpawn;
    [SerializeField] GameObject vfxDeath;
    private Animator animator;  // Référence à l'Animator de l'ennemi
    //private bool NearTarget = false;  // Indicateur si l'ennemi est à portée du cristal

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

            Debug.Log("Crystal repéré");
            if (animator != null)
            {
                animator.SetBool("NearTarget", true);
            }

        }
    }
    private void Start()
    {
        animator = GetComponent<Animator>();  // Récupère l'Animator attaché à l'ennemi
        if (animator == null)
        {
            Debug.LogError("L'Animator de l'ennemi n'a pas été trouvé !");
        }
    }

}
