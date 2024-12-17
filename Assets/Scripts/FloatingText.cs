using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    public float speed = 2f; // Vitesse de montée du texte
    public float lifetime = 1.5f; // Durée avant destruction du texte
    public Vector3 offset = new Vector3(0, 180, 0); // L'offset pour retourner le texte si nécessaire

    private Transform playerCamera; // Référence à la caméra du joueur

    private void Start()
    {
        // Récupérer la caméra principale
        playerCamera = Camera.main.transform;

        // Détruire le texte après un certain temps
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Faire monter le texte
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // Faire en sorte que le texte regarde toujours la caméra
        if (playerCamera != null)
        {
            transform.LookAt(playerCamera);

            // Appliquer un offset si nécessaire pour retourner le texte
            transform.Rotate(offset);
        }
    }
}
