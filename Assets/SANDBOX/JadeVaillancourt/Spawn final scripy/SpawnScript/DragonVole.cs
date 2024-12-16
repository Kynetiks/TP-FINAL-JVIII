using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonVole : MonoBehaviour
{
    public float speed = 5f; // Vitesse de déplacement
    private Transform target; // La cible (l'objet avec le tag "Crystal")
    private Rigidbody rb; // Le Rigidbody de l'objet

    void Start()
    {
        // Récupère le Rigidbody attaché à l'objet
        rb = GetComponent<Rigidbody>();

        // Cherche l'objet avec le tag "Crystal"
        GameObject crystal = GameObject.FindGameObjectWithTag("Crystal");

        // Si l'objet Crystal est trouvé, récupère sa position
        if (crystal != null)
        {
            target = crystal.transform;
        }
        else
        {
            Debug.LogWarning("Aucun objet avec le tag 'Crystal' trouvé.");
        }
    }

    void FixedUpdate()
    {
        // Si une cible existe, déplace l'objet vers elle
        if (target != null)
        {
            MoveTowards();
        }
    }

    void MoveTowards()
    {
        // Calcul du vecteur de direction vers la cible
        Vector3 direction = target.position - transform.position;

        // Normalisation du vecteur de direction
        direction.Normalize();

        // Applique une force pour déplacer l'objet vers la cible
        rb.velocity = direction * speed;
    }
}