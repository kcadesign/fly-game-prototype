using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerWalk : PlayerMovementInitialise
{


    [Header("References")]
    //private Rigidbody rigidBody;
    //private PlayerControls playerControls;

    [SerializeField] private float walkSpeed = 1f;

    [HideInInspector] public Vector2 leftStickAxis;
    /*
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerControls = new PlayerControls();
    }*/

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
        //Debug.Log(leftStickAxis);

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
        Vector3 movementDirection = leftStickAxis.y * transform.forward + leftStickAxis.x * transform.right;
        Vector3 movementForce = walkSpeed * Time.deltaTime * movementDirection;

        if (leftStickAxis.y != 0 || leftStickAxis.x != 0)
        {
            rigidBody.AddForce(movementForce, ForceMode.Impulse);
        }
    }


}


