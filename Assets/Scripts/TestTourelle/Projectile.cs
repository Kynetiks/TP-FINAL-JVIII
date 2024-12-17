using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;      // Vitesse du projectile
    public Transform target;       // Cible vers laquelle le projectile se d�place
    public float damage = 10f;     // D�g�ts inflig�s � la cible (si besoin)
    public EnemyBehavior enemyBehavior;

    void Start()
    {
        // Si la cible n'est pas d�finie, on la trouve automatiquement
        if (target == null)
        {
            Debug.LogError("Aucune cible assign�e au projectile !");
            Destroy(gameObject); // D�truire le projectile si aucune cible n'est d�finie
        }


    }

    void Update()
    {
        if (target != null)
        {
            // Se d�placer vers la cible
            Vector3 direction = target.position - transform.position;  // Calculer la direction vers la cible
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World); // D�placer le projectile

            // V�rifier si le projectile atteint la cible
            if (Vector3.Distance(transform.position, target.position) <= 0.1f)
            {
                // Ici, on pourrait appliquer des d�g�ts ou d�truire le projectile
                Destroy(gameObject); // D�truire le projectile lorsque celui-ci atteint la cible
                if (enemyBehavior != null)
                {
                    // Appeler la m�thode Death() de ScriptB
                    enemyBehavior.Death();
                }
            }
        }
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    // V�rifie si l'objet avec lequel le projectile entre en collision a le script EnemyBehavior
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        // R�cup�re le script EnemyBehavior attach� � l'ennemi
    //        EnemyBehavior enemyBehavior = collision.gameObject.GetComponent<EnemyBehavior>();

    //        // V�rifie si EnemyBehavior a bien �t� trouv�
    //        if (enemyBehavior != null)
    //        {
    //            // Appeler la fonction Death() du script EnemyBehavior
    //            enemyBehavior.Death();
    //        }
    //        else
    //        {
    //            Debug.LogError("EnemyBehavior n'a pas �t� trouv� sur l'objet de l'ennemi.");
    //        }

    //        // D�truire le projectile (si vous le souhaitez)
    //        Destroy(gameObject);
    //    }
    //}
}
