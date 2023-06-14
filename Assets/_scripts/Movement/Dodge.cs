using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : PlayerMovementInitialise
{
    [SerializeField] private float _dodgeSpeed = 100f;
    private Vector3 _dodgeDirection;

    private bool _isDodging;
    private bool _previousButtonState = false;


    private void FixedUpdate()
    {
        HandleDodgeLogic();
    }

    private void HandleDodgeLogic()
    {
        bool currentButtonState = _handlePlayerInput.LeftShoulderPressed;

        if (!_handlePlayerInput.LeftShoulderPressed)
        {
            _isDodging = false;
        }
        else if (_handlePlayerInput.LeftShoulderPressed && currentButtonState && !_previousButtonState)
        {
            _isDodging = !_isDodging;
            PerformDodge();
        }

        _previousButtonState = currentButtonState;
    }

    private void PerformDodge()
    {
        _dodgeDirection = transform.forward;
        
        Vector3 dodgeVelocity = _dodgeDirection * _dodgeSpeed;
        dodgeVelocity.y = 0f;

        rigidBody.velocity = dodgeVelocity;
    }
}
