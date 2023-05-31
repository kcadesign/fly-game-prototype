using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandlePlayerInput : MonoBehaviour
{
    protected PlayerControls playerControls;

    private Vector2 _leftStickAxis;
    private Vector2 _rightStickAxis;
    private float _leftTriggerValue = 0;
    private float _rightTriggerValue = 0;
    private bool _rightShoulderPressed;
    private bool _leftShoulderPressed;
    private bool _buttonSouthPressed = false;

    public Vector2 LeftStickAxis { get { return _leftStickAxis; } }
    public Vector2 RightStickAxis { get { return _rightStickAxis; } }
    public float LeftTriggerValue { get { return _leftTriggerValue; } }
    public float RightTriggerValue { get { return _rightTriggerValue; } }
    public bool RightShoulderPressed { get { return _rightShoulderPressed; } }
    public bool ButtonSouthPressed { get { return _buttonSouthPressed; } }
    public bool LeftShoulderPressed { get { return _leftShoulderPressed; } }

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Gameplay.Enable();

        playerControls.Gameplay.Move.performed += Move_performed;
        playerControls.Gameplay.Move.canceled += Move_Cancelled;

        playerControls.Gameplay.FlyDown.performed += FlyDown_performed;
        playerControls.Gameplay.FlyDown.canceled += FlyDown_canceled;

        playerControls.Gameplay.FlyUp.performed += FlyUp_performed;
        playerControls.Gameplay.FlyUp.canceled += FlyUp_Cancelled;

        playerControls.Gameplay.Hover.started += Hover_performed;
        playerControls.Gameplay.Hover.canceled += Hover_canceled;

        playerControls.Gameplay.Look.performed += Look_performed;
        playerControls.Gameplay.Look.canceled += Look_canceled;

        playerControls.Gameplay.LandTakeOff.performed += LandTakeOff_performed;
        playerControls.Gameplay.LandTakeOff.canceled += LandTakeOff_cancelled;

        playerControls.Gameplay.Dash.started += Dash_performed;
        playerControls.Gameplay.Dash.canceled += Dash_canceled;

    }


    private void OnDisable()
    {
        playerControls.Gameplay.Disable();

        playerControls.Gameplay.Move.performed -= Move_performed;
        playerControls.Gameplay.Move.canceled -= Move_Cancelled;

        playerControls.Gameplay.FlyDown.performed -= FlyDown_performed;
        playerControls.Gameplay.FlyDown.canceled -= FlyDown_canceled;

        playerControls.Gameplay.FlyUp.performed -= FlyUp_performed;
        playerControls.Gameplay.FlyUp.canceled -= FlyUp_Cancelled;

        playerControls.Gameplay.Hover.started -= Hover_performed;
        playerControls.Gameplay.Hover.canceled -= Hover_canceled;

        playerControls.Gameplay.Look.performed -= Look_performed;
        playerControls.Gameplay.Look.canceled -= Look_canceled;

        playerControls.Gameplay.LandTakeOff.performed -= LandTakeOff_performed;
        playerControls.Gameplay.LandTakeOff.canceled -= LandTakeOff_cancelled;

        playerControls.Gameplay.Dash.started -= Dash_performed;
        playerControls.Gameplay.Dash.canceled -= Dash_canceled;

    }

    private void Move_performed(InputAction.CallbackContext value) => _leftStickAxis = value.ReadValue<Vector2>();
    private void Move_Cancelled(InputAction.CallbackContext value) => _leftStickAxis = Vector2.zero;

    private void FlyDown_performed(InputAction.CallbackContext value) => _leftTriggerValue = value.ReadValue<float>();
    private void FlyDown_canceled(InputAction.CallbackContext value) => _leftTriggerValue = 0;

    private void FlyUp_performed(InputAction.CallbackContext value) => _rightTriggerValue = value.ReadValue<float>();
    private void FlyUp_Cancelled(InputAction.CallbackContext value) => _rightTriggerValue = 0;

    private void Hover_performed(InputAction.CallbackContext value) => _rightShoulderPressed = true;
    private void Hover_canceled(InputAction.CallbackContext value) => _rightShoulderPressed = false;

    private void Look_performed(InputAction.CallbackContext value) => _rightStickAxis = value.ReadValue<Vector2>();
    private void Look_canceled(InputAction.CallbackContext value) => _rightStickAxis = Vector2.zero;

    private void LandTakeOff_performed(InputAction.CallbackContext value)
    {
        _buttonSouthPressed = true;
        //print("South button pressed: " + _buttonSouthPressed);
    }
    private void LandTakeOff_cancelled(InputAction.CallbackContext value)
    {
        _buttonSouthPressed = false;
        //print("South button pressed: " + _buttonSouthPressed);
    }

    private void Dash_performed(InputAction.CallbackContext value)
    {
        _leftShoulderPressed = true;
        print("Left shoulder pressed: " + _leftShoulderPressed);
    }
    private void Dash_canceled(InputAction.CallbackContext value)
    {
        _leftShoulderPressed = false;
        print("Left shoulder pressed: " + _leftShoulderPressed);
    }

}
