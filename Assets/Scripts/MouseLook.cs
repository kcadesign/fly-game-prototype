using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float mouseLookSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleMouseLook();
    }

    private void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseLookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * mouseLookSpeed;

        // Rotate the player object around its y-axis (left and right)
        transform.Rotate(0f, mouseX, 0f);

        // Rotate the player object around its x-axis (up and down)
        Vector3 currentRotation = transform.rotation.eulerAngles;
        float newRotationX = currentRotation.x - mouseY;
        transform.rotation = Quaternion.Euler(newRotationX, currentRotation.y, 0);
    }
}
