using UnityEngine;

public class TourelleV10 : MonoBehaviour
{
    public float detectionRange = 10f;  // La portée de détection de la tourelle
    public float rotationSpeed = 5f;    // Vitesse à laquelle la tourelle tourne vers la cible
    public float fireRate = 1f;         // Intervalle entre les tirs (en secondes)
    public GameObject bulletPrefab;     // Le prefab de la balle/Projectiles que la tourelle tire
    public Transform firePoint;         // Le point d'où le projectile sera tiré (souvent l'avant de la tourelle)
    public Transform head;              // La tête de la tourelle (l'objet qui doit tourner)

    private GameObject currentTarget;   // L'ennemi actuellement ciblé
    private float lastFireTime;         // Le moment du dernier tir

    void Update()
    {
        // Rechercher la cible la plus proche dans la portée de la tourelle
        if (currentTarget == null || Vector3.Distance(transform.position, currentTarget.transform.position) > detectionRange)
        {
            FindNewTarget();
        }

        if (currentTarget != null)
        {
            // Tourner la tête de la tourelle vers la cible
            RotateHeadTowardsTarget();

            // Si c'est le bon moment pour tirer, tirer
            if (Time.time - lastFireTime >= fireRate)
            {
                Shoot();
            }
        }
    }

    // Recherche la cible la plus proche dans la portée
    void FindNewTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < closestDistance && distanceToEnemy <= detectionRange)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        currentTarget = closestEnemy;
    }

    // Tourner la tête de la tourelle vers la cible (seule la tête bouge)
    void RotateHeadTowardsTarget()
    {
        Vector3 directionToTarget = currentTarget.transform.position - head.position;  // Utiliser la position de la tête de la tourelle
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
        head.rotation = Quaternion.Slerp(head.rotation, targetRotation, Time.deltaTime * rotationSpeed); // Appliquer la rotation à la tête
    }

    // Tirer sur la cible
    void Shoot()
    {
        if (bulletPrefab && firePoint)
        {
            // Instancier un nouveau projectile et orienter correctement sa rotation
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // Assigner la cible au projectile
            Projectile projectileScript = bullet.GetComponent<Projectile>();
            if (projectileScript != null)
            {
                projectileScript.target = currentTarget.transform;  // Assigner la cible au projectile
            }

            // Orienter le projectile dans la même direction que la tourelle
            bullet.transform.forward = firePoint.forward; // Cette ligne garantit que le projectile est orienté dans la direction de la tourelle

            lastFireTime = Time.time;  // Mettre à jour le temps du dernier tir
        }
    }
}
