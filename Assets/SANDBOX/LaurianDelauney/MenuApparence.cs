using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MenuFollowController : MonoBehaviour
{
    public XRController controller;  // Reference to the XR controller (either left or right)
    public Transform menuTransform;  // Reference to the Canvas Transform

    public Vector3 offset;  // Offset to position the menu relative to the controller

    void Update()
    {
        if (controller)
        {
            // Get the position of the controller
            Vector3 controllerPosition = controller.transform.position;

            // Position the menu at the controller's position with the offset
            menuTransform.position = controllerPosition + offset;

            // Optionally, align the menu's rotation to the controller's rotation
            menuTransform.rotation = controller.transform.rotation;
        }
    }
}
