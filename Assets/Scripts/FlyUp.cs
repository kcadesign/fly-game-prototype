using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlyUp : MonoBehaviour
{
    [SerializeField] private float verticalSpeed = 0;
    private float inputValue = 0;

    private Rigidbody rigidBody;
    private PlayerControls playerControls;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Gameplay.Enable();
        playerControls.Gameplay.FlyUp.performed += FlyUp_performed;
        playerControls.Gameplay.FlyUp.canceled += FlyUp_Cancelled;
    }

    private void OnDisable()
    {
        playerControls.Gameplay.Disable();
        playerControls.Gameplay.FlyUp.performed -= FlyUp_performed;
        playerControls.Gameplay.FlyUp.canceled -= FlyUp_Cancelled;
    }

    private void FixedUpdate()
    {
        //Debug.Log(inputValue);
        HandleFlyUp();
    }

    private void FlyUp_performed(InputAction.CallbackContext value)
    {
        inputValue = value.ReadValue<float>();
    }


    private void FlyUp_Cancelled(InputAction.CallbackContext value)
    {
        inputValue = 0;
    }

    
    public void HandleFlyUp()
    {
        rigidBody.AddForce(inputValue * verticalSpeed * Time.deltaTime * Vector3.up, ForceMode.Impulse);
    }
    
}
