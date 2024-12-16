using UnityEngine;
using System.Collections;

public class ChangeMaterialColor : MonoBehaviour
{
    public Renderer objectRenderer;  // Le Renderer de l'objet dont le matériau sera modifié
    public float changeInterval = 30f;  // L'intervalle en secondes entre chaque changement de couleur
    public Color[] colors;  // Tableau de couleurs à utiliser

    private int currentColorIndex = 0;  // Index pour suivre la couleur actuelle

    private void Start()
    {
        if (objectRenderer == null)
        {
            objectRenderer = GetComponent<Renderer>();  // Si le Renderer n'est pas assigné, on le prend depuis l'objet
        }

        // Démarre la coroutine pour changer la couleur
        StartCoroutine(ChangeColorOverTime());
    }

    private IEnumerator ChangeColorOverTime()
    {
        while (true)  // Cette boucle continue indéfiniment
        {
            // Applique la couleur courante à l'objet
            objectRenderer.material.color = colors[currentColorIndex];

            // Incrémente l'index pour la prochaine couleur
            currentColorIndex++;

            // Si l'index dépasse la taille du tableau, le réinitialiser à 0 (pour recommencer les couleurs)
            if (currentColorIndex >= colors.Length)
            {
                currentColorIndex = 0;
            }

            // Attendre avant de changer la couleur à nouveau (ici 30 secondes)
            yield return new WaitForSeconds(changeInterval);
        }
    }
}
