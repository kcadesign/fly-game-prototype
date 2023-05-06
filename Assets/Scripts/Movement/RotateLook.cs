using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLook : PlayerMovementInitialise
{
    [SerializeField] private float lookSensitivity = 0;
    private Vector2 rightStickAxis;

    //private PlayerControls playerControls;

    private float rotationX = 0f;
    private float rotationY = 0f;

    /*
    void Awake()
    {
        playerControls = new PlayerControls();
    }
    */

    private void OnEnable()
    {
        playerControls.Gameplay.Enable();
        playerControls.Gameplay.Look.performed += Look_performed;
        playerControls.Gameplay.Look.canceled += Look_canceled;
    }

    private void OnDisable()
    {
        playerControls.Gameplay.Disable();
        playerControls.Gameplay.Look.performed -= Look_performed;
        playerControls.Gameplay.Look.canceled -= Look_canceled;
    }

    private void FixedUpdate()
    {
        //Debug.Log(rightStickAxis);
        HandleRotation();
    }


    private void Look_performed(UnityEngine.InputSystem.InputAction.CallbackContext value)
    {
        rightStickAxis = value.ReadValue<Vector2>();
    }

    private void Look_canceled(UnityEngine.InputSystem.InputAction.CallbackContext value)
    {
        rightStickAxis = Vector2.zero;
    }

    private void HandleRotation()
    {
        float lookX = rightStickAxis.x * lookSensitivity * Time.deltaTime;
        float lookY = rightStickAxis.y * lookSensitivity * Time.deltaTime;

        rotationY += lookX;
        rotationX -= lookY;

        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
    }


}
