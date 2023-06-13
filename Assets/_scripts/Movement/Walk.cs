using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : PlayerMovementInitialise
{
    [SerializeField] private float _walkSpeed = 1f;
    [SerializeField] private float _turnSpeed = 1f;

    void FixedUpdate()
    {
        HandleForwardMovement();
        HandleRotation();
    }

    private void HandleForwardMovement()
    {
        Vector3 movementDirection;

        movementDirection.x = _handlePlayerInput.LeftStickAxis.x;
        movementDirection.y = 0f;
        movementDirection.z = _handlePlayerInput.LeftStickAxis.y;

        transform.Translate(0f, 0f, movementDirection.z * _walkSpeed * Time.deltaTime);
        /*
        // Convert movement direction from world space to camera's local space
        movementDirection = Camera.main.transform.TransformDirection(movementDirection);

        Vector3 movement = _walkSpeed * Time.deltaTime * movementDirection;
        movement.y = 0f;

        if (_handlePlayerInput.LeftStickAxis.magnitude > 0)
        {
            transform.position += movement;
        }
        */
    }

    private void HandleRotation()
    {
        Vector3 positionToLookAt;

        positionToLookAt.x = _handlePlayerInput.LeftStickAxis.x;
        positionToLookAt.y = 0f;
        positionToLookAt.z = _handlePlayerInput.LeftStickAxis.y;

        transform.Rotate(0f, positionToLookAt.x * _turnSpeed * Time.deltaTime, 0f);
        /*
        positionToLookAt = Camera.main.transform.TransformDirection(positionToLookAt);

        if (_handlePlayerInput.LeftStickAxis.magnitude > 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _turnSpeed * Time.deltaTime);
        }
        */
    }
}
