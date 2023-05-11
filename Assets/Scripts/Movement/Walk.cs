using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : PlayerMovementInitialise
{
    [SerializeField] private float _walkSpeed = 1f;
    [SerializeField] private float _turnSpeed = 1f;

    void Update()
    {
        HandleWalking();
    }

    private void HandleWalking()
    {
        float horizontalInput = _handlePlayerInput.LeftStickAxis.x;
        float verticalInput = _handlePlayerInput.LeftStickAxis.y;

        // Rotate player left or right based on horizontal input
        transform.Rotate(0f, horizontalInput * _turnSpeed * Time.deltaTime, 0f);

        // Move player forward or backward based on vertical input
        transform.Translate(0f, 0f, verticalInput * _walkSpeed * Time.deltaTime);
    }
}
