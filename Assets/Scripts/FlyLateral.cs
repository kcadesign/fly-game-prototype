using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class FlyLateral : MonoBehaviour
{
    [Header("References")]
    private Rigidbody rigidBody;
    private PlayerControls playerControls;

    
    [Header("Flying Values")]
    [SerializeField] private float lateralFlySpeed = 5f;
    [SerializeField] private float verticalLiftValue = 0.5f;

    [HideInInspector] public Vector2 leftStickAxis;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerControls = new PlayerControls();
    }

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

        HandleLateralMovement();
    }

    private void Move_performed(InputAction.CallbackContext value)
    {
        leftStickAxis = value.ReadValue<Vector2>();
    }

    private void Move_Cancelled(InputAction.CallbackContext value)
    {
        leftStickAxis = Vector2.zero;
    }
    
    private void HandleLateralMovement()
    {
        Vector3 movementDirection = (leftStickAxis.y * transform.forward + leftStickAxis.x * transform.right).normalized;
        Vector3 movementForce = lateralFlySpeed * Time.deltaTime * movementDirection + VerticalLift();

        if (leftStickAxis.y != 0 || leftStickAxis.x != 0)
        {
            rigidBody.AddForce(movementForce, ForceMode.Impulse);
        }
    }

    private Vector3 VerticalLift()
    {
        return new Vector3(0, verticalLiftValue, 0);
    }
    
}
