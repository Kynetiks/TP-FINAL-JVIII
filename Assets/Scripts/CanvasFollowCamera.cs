using UnityEngine;

public class CanvasFollowCamera : MonoBehaviour
{
    // Référence à la caméra principale
    public Camera mainCamera;

    // Distance de l'UI par rapport à la caméra
    public float distanceFromCamera = 2f;

    // Angle d'orientation de l'UI par rapport à la caméra (facultatif)
    public Vector3 rotationOffset = Vector3.zero;

    // ^Distance de l'UI par rapport à la caméra (facultatif)
    public Vector3 postionOffset = Vector3.zero;


    void Update()
    {
        // Si la caméra principale n'est pas assignée, on récupère la caméra principale par défaut
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        // Placer le canvas devant la caméra en ajustant la distance
        if (mainCamera != null)
        {
            Vector3 directionToFace = mainCamera.transform.forward;
            Vector3 newPosition = mainCamera.transform.position + directionToFace + postionOffset;

            // Positionner le Canvas devant la caméra
            transform.position = newPosition;

            // Optionnel : Ajuster la rotation pour toujours faire face à la caméra
            transform.rotation = Quaternion.LookRotation(directionToFace) * Quaternion.Euler(rotationOffset);
        }
    }
}
