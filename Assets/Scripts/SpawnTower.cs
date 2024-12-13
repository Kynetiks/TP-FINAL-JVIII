using System.Collections.Generic;
using UnityEngine;
using Meta.XR.MRUtilityKit;
using TMPro;

public class DisplayLabel : MonoBehaviour
{
    [Header("Raycast Settings")]
    [Tooltip("Point de départ du rayon pour détecter les ancres.")]
    [SerializeField] private Transform rayStartPoint;

    [Tooltip("Longueur maximale du rayon.")]
    [SerializeField] private float rayLength = 8.0f;

    [Tooltip("Filtre des étiquettes des ancres à détecter.")]
    [SerializeField] private MRUKAnchor.SceneLabels labelFlag;

    [Header("Gizmo Display")]
    [Tooltip("Objet Gizmo affiché à l'emplacement de l'ancre détectée.")]
    [SerializeField] private GameObject gizmoDisplay;

    [Tooltip("Texte affiché sur le Gizmo.")]
    [SerializeField] private TextMeshPro gizmoLabelText;

    [Tooltip("Détermine si le texte du Gizmo est visible.")]
    [SerializeField] private bool showGizmoLabelText;

    [Header("Tower Spawn")]
    [Tooltip("Préfabriqué de la tour à instancier.")]
    [SerializeField] private GameObject towerPrefab;

    [Tooltip("Bouton utilisé pour faire apparaître une tour.")]
    [SerializeField] private OVRInput.Button spawnButton;

    // Variables privées
    private MRUKRoom room; // Référence à la pièce actuelle détectée par MRUK
    private Vector3 hitPoint; // Point d'impact du rayon

    private void Start()
    {
        // Initialisation : récupération de la pièce actuelle
        room = MRUK.Instance.GetCurrentRoom();

        // Configurer la visibilité du texte du Gizmo
        gizmoLabelText.enabled = showGizmoLabelText;
    }

    private void Update()
    {
        // Vérifier si une pièce a été détectée
        if (room == null)
        {
            Debug.LogWarning("Aucune pièce détectée.");
            return;
        }

        // Gérer le raycast pour détecter des ancres
        ProcessRaycast();
    }

    /// <summary>
    /// Effectue un raycast à partir du point de départ pour détecter les ancres dans la scène.
    /// </summary>
    private void ProcessRaycast()
    {
        Ray ray = new Ray(rayStartPoint.position, rayStartPoint.forward);

        // Lancer le rayon et vérifier les collisions avec des ancres
        if (room.Raycast(ray, rayLength, new LabelFilter(labelFlag), out RaycastHit hitInfo, out MRUKAnchor anchor))
        {
            // Si un objet est détecté, gérer l'affichage du Gizmo
            HandleGizmoDisplay(hitInfo, anchor);

            // Vérifier si l'angle du Gizmo est correct
            if (IsGizmoPointingSkyward())
            {
                HandleControllerAction(OVRInput.Controller.RTouch);
            }
        }
        else
        {
            // Désactiver le Gizmo si aucun objet n'est détecté
            gizmoDisplay.SetActive(false);
        }
    }

    /// <summary>
    /// Active et configure l'affichage du Gizmo en fonction de l'objet détecté.
    /// </summary>
    /// <param name="hitInfo">Informations sur l'impact du rayon.</param>
    /// <param name="anchor">Ancre détectée par le raycast.</param>
    private void HandleGizmoDisplay(RaycastHit hitInfo, MRUKAnchor anchor)
    {
        gizmoDisplay.SetActive(true);

        // Positionner et orienter le Gizmo
        hitPoint = hitInfo.point;
        gizmoDisplay.transform.position = hitPoint;
        gizmoDisplay.transform.rotation = Quaternion.LookRotation(-hitInfo.normal);

        // Mettre à jour le texte affiché
        gizmoLabelText.text = $"Anchor: {anchor.Label}";
    }

    /// <summary>
    /// Vérifie si le Gizmo pointe dans une direction "ciel".
    /// </summary>
    /// <returns>True si l'angle est dans les limites acceptables.</returns>
    private bool IsGizmoPointingSkyward()
    {
        float rotationXGizmo = gizmoDisplay.transform.rotation.eulerAngles.x;
        const float minAngle = 89.0f;
        const float maxAngle = 91.0f;

        // Vérifier si l'angle est dans la plage acceptée
        if (rotationXGizmo >= minAngle && rotationXGizmo <= maxAngle)
        {
            Debug.LogWarning("L'objet pointe vers le ciel !");
            return true;
        }
        else
        {
            Debug.LogWarning("L'objet ne pointe pas vers le ciel.");
            return false;
        }
    }

    /// <summary>
    /// Gère les actions effectuées par le contrôleur lorsqu'un bouton est pressé.
    /// </summary>
    /// <param name="controller">Contrôleur utilisé pour l'interaction.</param>
    private void HandleControllerAction(OVRInput.Controller controller)
    {
        // Vérifier si le bouton de création de tour est pressé
        if (OVRInput.GetDown(spawnButton, controller))
        {
            Instantiate(towerPrefab, hitPoint, Quaternion.identity);
        }
    }
}


