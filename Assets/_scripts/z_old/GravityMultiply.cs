using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityMultiply : PlayerMovementInitialise
{
    public float GravityMultiplier = 0;

    void FixedUpdate()
    {
        HandleGravity(_handlePlayerInput.LeftStickAxis, _handlePlayerInput.RightTriggerValue);
    }

    private void HandleGravity(Vector2 leftStickInput, float rightTriggerInput)
    {
        float movementInput = leftStickInput.magnitude + rightTriggerInput;

        if (movementInput != 0)
        {
            return;
        }
        else
        {
            rigidBody.AddForce(GravityMultiplier * Physics.gravity.magnitude * Vector3.down, ForceMode.Acceleration);
        }
    }
}
