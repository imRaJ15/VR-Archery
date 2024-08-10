using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;

public class XRPlayerMovement : MonoBehaviour
{
    public float speed = 3.0f; // Movement speed of the player
    public XROrigin xrOrigin; // The XR Origin containing the camera and controllers
    public InputActionProperty moveInput; // Reference to the input action for movement

    void Update()
    {
        // Get the input vector from the right thumbstick
        Vector2 input = moveInput.action.ReadValue<Vector2>();

        // Convert input to a direction vector
        Vector3 direction = new Vector3(input.x, 0, input.y);

        // Rotate the direction vector based on the camera's current Y rotation
        direction = Quaternion.Euler(0, xrOrigin.Camera.transform.eulerAngles.y, 0) * direction;

        // Move the XR Origin
        xrOrigin.MoveCameraToWorldLocation(xrOrigin.transform.position + direction * speed * Time.deltaTime);
    }
}
