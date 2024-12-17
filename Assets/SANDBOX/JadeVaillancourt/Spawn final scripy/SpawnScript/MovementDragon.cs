using UnityEngine;

public class MoveToCrystal : MonoBehaviour
{
    public float moveSpeed = 5f;  // Vitesse de déplacement
    private Rigidbody rb;         // Référence au Rigidbody
    private Transform target;

    void Start()
    {
        // Récupère le Rigidbody attaché à cet objet
        rb = GetComponent<Rigidbody>();

        // Cherche l'objet avec le tag "Crystal"
        GameObject targetObject = GameObject.FindGameObjectWithTag("Crystal");

        if (targetObject != null)
        {
            target = targetObject.transform;
        }
        else
        {
            Debug.LogWarning("Aucun objet avec le tag 'Crystal' trouvé !");
        }
    }

    void FixedUpdate()
    {
        // Si l'objet cible existe
        if (target != null)
        {
            // Direction vers l'objet cible
            Vector3 direction = (target.position - transform.position).normalized;

            // Applique une force pour déplacer l'objet vers la cible
            rb.velocity = direction * moveSpeed; // Utilise la vélocité pour un mouvement fluide
        }
    }
}