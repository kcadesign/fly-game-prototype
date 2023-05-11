using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : PlayerMovementInitialise
{

    private void Update()
    {
        HandleHover();
    }

    private void HandleHover()
    {
        if (_handlePlayerInput.RightShoulderPressed)
        {
            rigidBody.isKinematic = true;
        }
        else
        {
            rigidBody.isKinematic = false;
        }
    }


}
