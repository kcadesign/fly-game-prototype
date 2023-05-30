using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateMachine : MonoBehaviour
{
    private Rigidbody rigidBody;
    private PlayerControls playerControls;

    // state variables
    PlayerBaseState _currentState;
    PlayerStateFactory _states;
    public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }



    public float lateralFlySpeed = 5f;
    public float verticalLiftAmount = 0.5f;

    private Vector2 _leftStickAxis;
    public Vector2 LeftStickAxis { get { return _leftStickAxis; } }

    [SerializeField] private float verticalFlySpeed = 0;
    [HideInInspector] public float rightTriggerValue = 0;


    public void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerControls = new PlayerControls();

        _states = new PlayerStateFactory(this);
        _currentState = _states.Flying();
        _currentState.EnterState();
    }

    private void OnEnable()
    {
        playerControls.Gameplay.Enable();
        playerControls.Gameplay.Move.performed += Move_performed;
        playerControls.Gameplay.Move.canceled += Move_Cancelled;
        playerControls.Gameplay.FlyUp.performed += FlyUp_performed;
        playerControls.Gameplay.FlyUp.canceled += FlyUp_Cancelled;
    }

    private void OnDisable()
    {
        playerControls.Gameplay.Disable();
        playerControls.Gameplay.Move.performed -= Move_performed;
        playerControls.Gameplay.Move.canceled -= Move_Cancelled;
        playerControls.Gameplay.FlyUp.performed -= FlyUp_performed;
        playerControls.Gameplay.FlyUp.canceled -= FlyUp_Cancelled;
    }



    void FixedUpdate()
    {
        HandleLateralMovement();
        HandleVerticalMovement();

    }

    public void SwitchState(PlayerBaseState state)
    {

    }

    private void Move_performed(InputAction.CallbackContext value)
    {
        _leftStickAxis = value.ReadValue<Vector2>();
    }

    private void Move_Cancelled(InputAction.CallbackContext value)
    {
        _leftStickAxis = Vector2.zero;
    }

    private void FlyUp_performed(InputAction.CallbackContext value)
    {
        rightTriggerValue = value.ReadValue<float>();
    }

    private void FlyUp_Cancelled(InputAction.CallbackContext value)
    {
        rightTriggerValue = 0;
    }

    private void HandleLateralMovement()
    {
        Vector3 movementDirection = (_leftStickAxis.y * transform.forward + _leftStickAxis.x * transform.right).normalized;
        Vector3 movementForce = lateralFlySpeed * Time.deltaTime * movementDirection + VerticalLift();

        if (_leftStickAxis.y != 0 || _leftStickAxis.x != 0)
        {
            rigidBody.AddForce(movementForce, ForceMode.Impulse);
        }
    }

    private Vector3 VerticalLift()
    {
        return new Vector3(0, verticalLiftAmount, 0);
    }

    public void HandleVerticalMovement()
    {
        rigidBody.AddForce(rightTriggerValue * verticalFlySpeed * Time.deltaTime * Vector3.up, ForceMode.Impulse);
    }

}
