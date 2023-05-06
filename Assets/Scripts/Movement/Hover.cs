using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : PlayerMovementInitialise
{
    //[Header("References")]
    //private Rigidbody rigidBody;

    //private PlayerControls playerControls;


    public bool isHoverToggled;
    /*
    // Start is called before the first frame update
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerControls = new PlayerControls();
    }
    */

    private void OnEnable()
    {
        playerControls.Gameplay.Enable();
        playerControls.Gameplay.Hover.started += Hover_performed;
        playerControls.Gameplay.Hover.canceled += Hover_canceled;
    }

    private void OnDisable()
    {
        playerControls.Gameplay.Disable();
        playerControls.Gameplay.Hover.started -= Hover_performed;
        playerControls.Gameplay.Hover.canceled -= Hover_canceled;
    }

    private void Hover_performed(UnityEngine.InputSystem.InputAction.CallbackContext value)
    {
        isHoverToggled = true;
    }

    private void Hover_canceled(UnityEngine.InputSystem.InputAction.CallbackContext value)
    {
        isHoverToggled = false;
    }

    private void FixedUpdate()
    {
        //print(isHoverToggled);
        HandleHover();
    }

    private void HandleHover()
    {
        if (isHoverToggled)
        {
            rigidBody.isKinematic = true;
        }
        else
        {
            rigidBody.isKinematic = false;
        }
    }


}
