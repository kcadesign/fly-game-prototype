using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFly : MonoBehaviour
{
    [Header("References")]
    private Rigidbody rigidBody;

    [Header("Flying Values")]
    [SerializeField] private float lateralFlySpeed = 5f;
    [SerializeField] private float verticalFlySpeed = 5f;
    [SerializeField] private float verticalLiftValue = 0.5f;

    //[SerializeField] private float mouseLookSpeed = 1f;

    [Header("Physical Values")]
    [SerializeField] private float gravityMultiplier = 1f;




    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

    }

   

    void FixedUpdate()
    {


        HandleFlying();

        //HandleMouseLookMove();
    }

    

    private void HandleFlying()
    {
        float forwardInput = Input.GetAxisRaw("Vertical");
        float lateralInput = Input.GetAxisRaw("Horizontal");

        Vector3 movementDirection = (forwardInput * transform.forward + lateralInput * transform.right).normalized;
        Vector3 movementForce = lateralFlySpeed * movementDirection + VerticalLift();

        if (movementDirection.magnitude == 0)
        {
            movementForce = Vector3.zero;
        }
        else
        {
            rigidBody.AddForce(movementForce, ForceMode.Impulse);
        }

        float verticalInput = Input.GetAxisRaw("Jump");
        Vector3 verticalForce = verticalFlySpeed * verticalInput * Vector3.up;

        if (verticalForce.magnitude == 0)
        {
            verticalForce = Vector3.zero;
            
        }
        else if (verticalInput != 0)
        {
            rigidBody.AddForce(verticalForce, ForceMode.Impulse);
        }

        if(forwardInput == 0 && lateralInput == 0 && verticalInput == 0)
        {
            rigidBody.AddForce(Vector3.down * Physics.gravity.magnitude * gravityMultiplier, ForceMode.Acceleration);
        }

        //print(rigidBody.velocity.y);
    }

    private Vector3 VerticalLift()
    {
        return new Vector3(0, verticalLiftValue, 0);
    }
    /*
    private void HandleMouseLookMove()
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
    */
}
