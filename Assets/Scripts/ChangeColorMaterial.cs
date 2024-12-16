using UnityEngine;
using System.Collections;

public class ChangeMaterialColor : MonoBehaviour
{
    public Renderer objectRenderer;  // Le Renderer de l'objet dont le mat�riau sera modifi�
    public float changeInterval = 30f;  // L'intervalle en secondes entre chaque changement de couleur
    public Color[] colors;  // Tableau de couleurs � utiliser

    private int currentColorIndex = 0;  // Index pour suivre la couleur actuelle

    private void Start()
    {
        if (objectRenderer == null)
        {
            objectRenderer = GetComponent<Renderer>();  // Si le Renderer n'est pas assign�, on le prend depuis l'objet
        }

        // D�marre la coroutine pour changer la couleur
        StartCoroutine(ChangeColorOverTime());
    }

    private IEnumerator ChangeColorOverTime()
    {
        while (true)  // Cette boucle continue ind�finiment
        {
            // Applique la couleur courante � l'objet
            objectRenderer.material.color = colors[currentColorIndex];

            // Incr�mente l'index pour la prochaine couleur
            currentColorIndex++;

            // Si l'index d�passe la taille du tableau, le r�initialiser � 0 (pour recommencer les couleurs)
            if (currentColorIndex >= colors.Length)
            {
                currentColorIndex = 0;
            }

            // Attendre avant de changer la couleur � nouveau (ici 30 secondes)
            yield return new WaitForSeconds(changeInterval);
        }
    }
}
