using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    private Rigidbody rigidBody;

    [Header("Speed Values")]
    [SerializeField] private float lateralSpeed = 5f;
    [SerializeField] private float verticalSpeed = 5f;
    [SerializeField] private float mouseLookSpeed = 1f;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        HandleMovement();

        HandleMouseLook();
    }

    private void HandleMovement()
    {
        HandleForwardMovement();
        HandleLateralMovement();
        HandleVerticalMovement();

        /*
        // Move forward or backward
        transform.position += speed * Time.deltaTime * verticalInput * transform.forward;

        // Strafe left and right
        transform.position += horizontalInput * speed * Time.deltaTime * transform.right;
        */

        // Move forward or backward with physics force

        // Strafe left and right with physics force

        // Move vertically with physics force

    }

    private void HandleForwardMovement()
    {
        float forwardInput = Input.GetAxisRaw("Vertical");
        Vector3 forwardForce = lateralSpeed * forwardInput * transform.forward;

        if (forwardInput != 0)
        {
            rigidBody.AddForce(forwardForce, ForceMode.Impulse);
        }
        else
        {
            forwardForce = Vector3.zero;
            rigidBody.AddForce(-rigidBody.velocity, ForceMode.Impulse);
        }
    }

    private void HandleLateralMovement()
    {
        float lateralInput = Input.GetAxisRaw("Horizontal");
        Vector3 lateralForce = lateralSpeed * lateralInput * transform.right;

        if (lateralInput != 0)
        {
            rigidBody.AddForce(lateralForce, ForceMode.Impulse);
        }
        else
        {
            lateralForce = Vector3.zero;
            rigidBody.AddForce(-rigidBody.velocity, ForceMode.Impulse);
        }
    }

    private void HandleVerticalMovement()
    {
        float verticalInput = Input.GetAxisRaw("Jump");
        Vector3 verticalForce = verticalSpeed * verticalInput * transform.up;

        if (verticalInput != 0)
        {
            rigidBody.AddForce(verticalForce, ForceMode.Impulse);
        }
        else
        {
            verticalForce = Vector3.zero;
            rigidBody.AddForce(-rigidBody.velocity, ForceMode.Impulse);
        }
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
