using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;      // Vitesse du projectile
    public Transform target;       // Cible vers laquelle le projectile se déplace
    public float damage = 10f;     // Dégâts infligés à la cible (si besoin)

    void Start()
    {
        // Si la cible n'est pas définie, on la trouve automatiquement
        if (target == null)
        {
            Debug.LogError("Aucune cible assignée au projectile !");
            Destroy(gameObject); // Détruire le projectile si aucune cible n'est définie
        }
    }

    void Update()
    {
        if (target != null)
        {
            // Se déplacer vers la cible
            Vector3 direction = target.position - transform.position;  // Calculer la direction vers la cible
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World); // Déplacer le projectile

            // Vérifier si le projectile atteint la cible
            if (Vector3.Distance(transform.position, target.position) <= 0.1f)
            {
                // Ici, on pourrait appliquer des dégâts ou détruire le projectile
                Destroy(gameObject); // Détruire le projectile lorsque celui-ci atteint la cible
            }
        }
    }
}
