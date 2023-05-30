using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : PlayerMovementInitialise
{
    [SerializeField] private float _dashSpeed = 100f;
    private Vector3 _dashDirection;

/*    
    private void Dash_performed(UnityEngine.InputSystem.InputAction.CallbackContext value)
    {
        HandleDash();
    }
    private void Dash_canceled(UnityEngine.InputSystem.InputAction.CallbackContext value)
    {
        return;
    }
*/

    private void FixedUpdate()
    {
        //print(dashDirection);
        HandleBoost();
    }

    private void HandleBoost()
    {
        if (!_handlePlayerInput.LeftShoulderPressed)
        {
            return;
        }
        else
        {
            _dashDirection = (_handlePlayerInput.LeftStickAxis.x * transform.right + _handlePlayerInput.LeftStickAxis.y * transform.forward) * _dashSpeed;
            rigidBody.AddForce(_dashDirection * Time.deltaTime, ForceMode.Impulse);
        }
    }
    
}
    