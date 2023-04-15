using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private float horizontalInput;
    private float verticalInput;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Move forward or backward
        Vector3 forwardForce = transform.forward * verticalInput * speed;
        rb.AddForce(forwardForce, ForceMode.Impulse);

        // Strafe left and right
        Vector3 lateralForce = transform.right * horizontalInput * speed;
        rb.AddForce(lateralForce, ForceMode.Impulse);

        /*
        // Turn left or right
        float turnAmount = horizontalInput * turnSpeed * Time.deltaTime;
        Quaternion turnOffset = Quaternion.Euler(0f, turnAmount, 0f);
        rb.MoveRotation(rb.rotation * turnOffset);
        */

        
    }

    private void HandleMouseLook()
    {

    }
}
