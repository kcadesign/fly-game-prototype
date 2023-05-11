using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Fly : PlayerMovementInitialise
{

    [SerializeField] private float lateralFlySpeed = 5f;
    [SerializeField] private float verticalLiftAmount = 0.5f;
    [SerializeField] private float verticalFlySpeed = 0;

    void FixedUpdate()
    {
        HandleLateralMovement();
        HandleVerticalMovement();
    }

    private void HandleLateralMovement()
    {
        Vector3 movementDirection = (_handlePlayerInput.LeftStickAxis.y * transform.forward + _handlePlayerInput.LeftStickAxis.x * transform.right).normalized;
        Vector3 movementForce = lateralFlySpeed * Time.deltaTime * movementDirection + VerticalLift();

        if (_handlePlayerInput.LeftStickAxis.magnitude != 0)
        {
            rigidBody.AddForce(movementForce, ForceMode.Impulse);
        }
    }

    private Vector3 VerticalLift()
    {
        return new Vector3(0, verticalLiftAmount, 0);
    }

    public void HandleVerticalMovement()
    {
        rigidBody.AddForce(_handlePlayerInput.RightTriggerValue * verticalFlySpeed * Time.deltaTime * Vector3.up, ForceMode.Impulse);
    }
}