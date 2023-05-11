using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandlePlayerInput : MonoBehaviour
{
    protected PlayerControls playerControls;

    private Vector2 _leftStickAxis;
    private Vector2 _rightStickAxis;
    private float _rightTriggerValue = 0;
    private bool _rightShoulderPressed;
    private bool _buttonSouthPressed = false;

    public Vector2 LeftStickAxis { get { return _leftStickAxis; } }
    public Vector2 RightStickAxis { get { return _rightStickAxis; } }
    public float RightTriggerValue { get { return _rightTriggerValue; } }
    public bool RightShoulderPressed { get { return _rightShoulderPressed; } }
    public bool ButtonSouthPressed { get { return _buttonSouthPressed; } }


    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Gameplay.Enable();

        playerControls.Gameplay.Move.performed += Move_performed;
        playerControls.Gameplay.Move.canceled += Move_Cancelled;

        playerControls.Gameplay.FlyUp.performed += FlyUp_performed;
        playerControls.Gameplay.FlyUp.canceled += FlyUp_Cancelled;

        playerControls.Gameplay.Hover.started += Hover_performed;
        playerControls.Gameplay.Hover.canceled += Hover_canceled;

        playerControls.Gameplay.Look.performed += Look_performed;
        playerControls.Gameplay.Look.canceled += Look_canceled;

        playerControls.Gameplay.LandTakeOff.performed += LandTakeOff_performed;
        playerControls.Gameplay.LandTakeOff.canceled += LandTakeOff_cancelled;
    }



    private void OnDisable()
    {
        playerControls.Gameplay.Disable();

        playerControls.Gameplay.Move.performed -= Move_performed;
        playerControls.Gameplay.Move.canceled -= Move_Cancelled;

        playerControls.Gameplay.FlyUp.performed -= FlyUp_performed;
        playerControls.Gameplay.FlyUp.canceled -= FlyUp_Cancelled;

        playerControls.Gameplay.Hover.started -= Hover_performed;
        playerControls.Gameplay.Hover.canceled -= Hover_canceled;

        playerControls.Gameplay.Look.performed -= Look_performed;
        playerControls.Gameplay.Look.canceled -= Look_canceled;

        playerControls.Gameplay.LandTakeOff.performed -= LandTakeOff_performed;
        playerControls.Gameplay.LandTakeOff.canceled -= LandTakeOff_cancelled;
    }

    private void Move_performed(InputAction.CallbackContext value) => _leftStickAxis = value.ReadValue<Vector2>();
    private void Move_Cancelled(InputAction.CallbackContext value) => _leftStickAxis = Vector2.zero;

    private void FlyUp_performed(InputAction.CallbackContext value) => _rightTriggerValue = value.ReadValue<float>();
    private void FlyUp_Cancelled(InputAction.CallbackContext value) => _rightTriggerValue = 0;

    private void Hover_performed(InputAction.CallbackContext value) => _rightShoulderPressed = true;
    private void Hover_canceled(InputAction.CallbackContext value) => _rightShoulderPressed = false;

    private void Look_performed(InputAction.CallbackContext value) => _rightStickAxis = value.ReadValue<Vector2>();
    private void Look_canceled(InputAction.CallbackContext value) => _rightStickAxis = Vector2.zero;

    private void LandTakeOff_performed(InputAction.CallbackContext obj) 
    {
        _buttonSouthPressed = true;
        print("South button pressed: " + _buttonSouthPressed);
    } 
    private void LandTakeOff_cancelled(InputAction.CallbackContext obj)
    {
        _buttonSouthPressed = false;
        print("South button pressed: " + _buttonSouthPressed);
    }


}
