using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyB : PlayerMovementInitialise
{
    [SerializeField] private float _flySpeed = 5f;
    [SerializeField] private float _rotationSpeed = 5f;
    [SerializeField] private float _verticalLiftAmount = 0.5f;
    [SerializeField] private float _verticalFlySpeed = 0;

    private void Update()
    {
        HandleRotation();
    }

    void FixedUpdate()
    {
        HandleForwardMovement();
        HandleVerticalMovement();
    }
    
    private void HandleForwardMovement()
    {
        Vector3 movementDirection;

        movementDirection.x = _handlePlayerInput.LeftStickAxis.x;
        movementDirection.y = 0f;
        movementDirection.z = _handlePlayerInput.LeftStickAxis.y;

        // Convert movement direction from camera's local space to world space
        movementDirection = Camera.main.transform.TransformDirection(movementDirection);

        Vector3 movementForce = _flySpeed * Time.deltaTime * movementDirection + VerticalLift();

        if (_handlePlayerInput.LeftStickAxis.magnitude != 0)
        {
            rigidBody.AddForce(movementForce, ForceMode.Impulse);
        }
    }
    
    private void HandleRotation()
    {
        Vector3 positionToLookAt;

        positionToLookAt.x = _handlePlayerInput.LeftStickAxis.x;
        positionToLookAt.y = 0f;
        positionToLookAt.z = _handlePlayerInput.LeftStickAxis.y;

        positionToLookAt = Camera.main.transform.TransformDirection(positionToLookAt);


        Quaternion currentRotation = transform.rotation;

        if (_handlePlayerInput.LeftStickAxis.magnitude > 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }
    }
    
    private Vector3 VerticalLift() => new Vector3(0, _verticalLiftAmount, 0);

    public void HandleVerticalMovement()
    {
        rigidBody.AddForce(_handlePlayerInput.RightTriggerValue * _verticalFlySpeed * Time.deltaTime * Vector3.up, ForceMode.Impulse);
    }
}
