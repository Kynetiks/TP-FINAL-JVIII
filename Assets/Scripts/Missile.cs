using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Missile : MonoBehaviour
{
    public GameObject floatingTextPrefab; // Référence au prefab de texte flottant
    private Transform trans; // Référence au transform de la caméra
    private Vector3 offset = new Vector3(0, 180, 0); // Offset pour inverser l'orientation

    private void Start()
    {
        // Trouver la caméra du joueur et récupérer son transform
        trans = Camera.main.transform; // Ou assigne ta caméra directement ici si tu as une référence
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Vérifie si l'objet avec lequel il entre en collision est un ennemi
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Récupère les points de l'ennemi
            Enemy enemyScript = collision.gameObject.GetComponent<Enemy>();
            int points = enemyScript != null ? enemyScript.points : 0;

            // Instancie le texte flottant au niveau de la collision
            if (floatingTextPrefab != null)
            {
                GameObject floatingText = Instantiate(floatingTextPrefab, collision.transform.position, Quaternion.identity);
                floatingText.GetComponent<TextMeshPro>().text = "+" + points; // Affiche les points de l'ennemi
            }

            // Détruit l'ennemi et le missile
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // Vérifie si le texte flottant est bien présent
        if (trans != null)
        {
            // Utilise LookAt pour orienter le texte vers la caméra
            floatingTextPrefab.transform.LookAt(trans);

            // Applique un offset pour ajuster l'orientation du texte (inversion ou autre)
            floatingTextPrefab.transform.Rotate(offset);
        }
    }
}
