using System.Collections.Generic;
using UnityEngine;
using Meta.XR.MRUtilityKit;
using TMPro;

public class SpawnTower : MonoBehaviour
{
    [Header("Raycast Settings")]
    [Tooltip("Point de d�part du rayon pour d�tecter les ancres.")]
    [SerializeField] private Transform rayStartPoint;

    [Tooltip("Longueur maximale du rayon.")]
    [SerializeField] private float rayLength = 8.0f;

    [Tooltip("Filtre des �tiquettes des ancres � d�tecter.")]
    [SerializeField] private MRUKAnchor.SceneLabels labelFlag;

    [Header("Gizmo Display")]
    [Tooltip("Objet Gizmo affich� � l'emplacement de l'ancre d�tect�e.")]
    [SerializeField] private GameObject gizmoDisplay;

    [Tooltip("Texte affich� sur le Gizmo.")]
    [SerializeField] private TextMeshPro gizmoLabelText;

    [Tooltip("D�termine si le texte du Gizmo est visible.")]
    [SerializeField] private bool showGizmoLabelText;

    [Header("Tower Spawn")]
    [Tooltip("Pr�fabriqu� de la tour � instancier.")]
    [SerializeField] public GameObject towerPrefab;

    [Tooltip("Bouton utilis� pour faire appara�tre une tour.")]
    [SerializeField] private OVRInput.Button spawnButton;

    // Variables priv�es
    private MRUKRoom room; // R�f�rence � la pi�ce actuelle d�tect�e par MRUK
    private Vector3 hitPoint; // Point d'impact du rayon

    private void Start()
    {
        // Initialisation : r�cup�ration de la pi�ce actuelle
        room = MRUK.Instance.GetCurrentRoom();

        // Configurer la visibilit� du texte du Gizmo
        gizmoLabelText.enabled = showGizmoLabelText;
    }

    private void Update()
    {
        // V�rifier si une pi�ce a �t� d�tect�e
        if (room == null)
        {
            Debug.LogWarning("Aucune pi�ce d�tect�e.");
            return;
        }

        // G�rer le raycast pour d�tecter des ancres
        ProcessRaycast();
    }

    /// <summary>
    /// Effectue un raycast � partir du point de d�part pour d�tecter les ancres dans la sc�ne.
    /// </summary>
    private void ProcessRaycast()
    {
        Ray ray = new Ray(rayStartPoint.position, rayStartPoint.forward);

        // Lancer le rayon et v�rifier les collisions avec des ancres
        if (room.Raycast(ray, rayLength, new LabelFilter(labelFlag), out RaycastHit hitInfo, out MRUKAnchor anchor))
        {
            // Si un objet est d�tect�, g�rer l'affichage du Gizmo
            HandleGizmoDisplay(hitInfo, anchor);

            // V�rifier si l'angle du Gizmo est correct
            if (IsGizmoPointingSkyward())
            {
                HandleControllerAction(OVRInput.Controller.RTouch);
            }
        }
        else
        {
            // D�sactiver le Gizmo si aucun objet n'est d�tect�
            gizmoDisplay.SetActive(false);
        }
    }

    /// <summary>
    /// Active et configure l'affichage du Gizmo en fonction de l'objet d�tect�.
    /// </summary>
    /// <param name="hitInfo">Informations sur l'impact du rayon.</param>
    /// <param name="anchor">Ancre d�tect�e par le raycast.</param>
    private void HandleGizmoDisplay(RaycastHit hitInfo, MRUKAnchor anchor)
    {
        gizmoDisplay.SetActive(true);

        // Positionner et orienter le Gizmo
        hitPoint = hitInfo.point;
        gizmoDisplay.transform.position = hitPoint;
        gizmoDisplay.transform.rotation = Quaternion.LookRotation(-hitInfo.normal);

        // Mettre � jour le texte affich�
        gizmoLabelText.text = $"Anchor: {anchor.Label}";
    }

    /// <summary>
    /// V�rifie si le Gizmo pointe dans une direction "ciel".
    /// </summary>
    /// <returns>True si l'angle est dans les limites acceptables.</returns>
    private bool IsGizmoPointingSkyward()
    {
        float rotationXGizmo = gizmoDisplay.transform.rotation.eulerAngles.x;
        const float minAngle = 89.0f;
        const float maxAngle = 91.0f;

        // V�rifier si l'angle est dans la plage accept�e
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
    /// G�re les actions effectu�es par le contr�leur lorsqu'un bouton est press�.
    /// </summary>
    /// <param name="controller">Contr�leur utilis� pour l'interaction.</param>
    private void HandleControllerAction(OVRInput.Controller controller)
    {
        // V�rifier si le bouton de cr�ation de tour est press�
        if (OVRInput.GetDown(spawnButton, controller))
        {
            Instantiate(towerPrefab, hitPoint, Quaternion.identity);
        }
    }
}


