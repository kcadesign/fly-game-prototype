using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerWalk : PlayerMovementInitialise
{
    [Header("References")]

    [SerializeField] private float walkSpeed = 1f;
    [SerializeField] private float turnSpeed = 1f;


    [HideInInspector] public Vector2 leftStickAxis;

    private float rotationY;

    private void OnEnable()
    {
        playerControls.Gameplay.Enable();
        playerControls.Gameplay.Move.performed += Move_performed;
        playerControls.Gameplay.Move.canceled += Move_Cancelled;
    }

    private void OnDisable()
    {
        playerControls.Gameplay.Disable();
        playerControls.Gameplay.Move.performed -= Move_performed;
        playerControls.Gameplay.Move.canceled -= Move_Cancelled;
    }

    void FixedUpdate()
    {
        HandleWalking();
    }

    private void Move_performed(InputAction.CallbackContext value)
    {
        leftStickAxis = value.ReadValue<Vector2>();
    }

    private void Move_Cancelled(InputAction.CallbackContext value)
    {
        leftStickAxis = Vector2.zero;
    }

    private void HandleWalking()
    {
        float rotateX = leftStickAxis.x * Time.deltaTime * turnSpeed;
        float movementY = leftStickAxis.y * Time.deltaTime;

        rotationY += rotateX;
        


        Vector3 movementForce = movementY * walkSpeed * transform.forward;

        if (leftStickAxis.y != 0 || leftStickAxis.x != 0)
        {
            rigidBody.AddForce(movementForce, ForceMode.Impulse);
            transform.rotation = Quaternion.Euler(0, rotationY, 0);

        }
    }


}


