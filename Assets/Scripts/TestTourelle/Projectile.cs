using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;      // Vitesse du projectile
    public Transform target;       // Cible vers laquelle le projectile se déplace
    public float damage = 10f;     // Dégâts infligés à la cible (si besoin)
    public EnemyBehavior enemyBehavior;

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
                if (enemyBehavior != null)
                {
                    // Appeler la méthode Death() de ScriptB
                    enemyBehavior.Death();
                }
            }
        }
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    // Vérifie si l'objet avec lequel le projectile entre en collision a le script EnemyBehavior
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        // Récupère le script EnemyBehavior attaché à l'ennemi
    //        EnemyBehavior enemyBehavior = collision.gameObject.GetComponent<EnemyBehavior>();

    //        // Vérifie si EnemyBehavior a bien été trouvé
    //        if (enemyBehavior != null)
    //        {
    //            // Appeler la fonction Death() du script EnemyBehavior
    //            enemyBehavior.Death();
    //        }
    //        else
    //        {
    //            Debug.LogError("EnemyBehavior n'a pas été trouvé sur l'objet de l'ennemi.");
    //        }

    //        // Détruire le projectile (si vous le souhaitez)
    //        Destroy(gameObject);
    //    }
    //}
}
