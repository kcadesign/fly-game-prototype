using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class Dash : PlayerMovementInitialise
{
    [Header("References")]
    //private Rigidbody rigidBody;

    //private PlayerControls playerControls;
    
    private FlyLateral flyLateral;


    [SerializeField] private float dashSpeed = 0f;
    private Vector3 dashDirection;
    
    // Start is called before the first frame update
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerControls = new PlayerControls();
    }
    

    private void Start()
    {
        flyLateral = GetComponent<FlyLateral>();
    }

    private void OnEnable()
    {
        playerControls.Gameplay.Enable();
        playerControls.Gameplay.Dash.started += Dash_performed;
        playerControls.Gameplay.Dash.canceled += Dash_canceled;
    }

    private void OnDisable()
    {
        playerControls.Gameplay.Disable();
        playerControls.Gameplay.Dash.started -= Dash_performed;
        playerControls.Gameplay.Dash.canceled -= Dash_canceled;
    }
    

    private void Dash_performed(UnityEngine.InputSystem.InputAction.CallbackContext value)
    {
        HandleDash();
    }


    private void Dash_canceled(UnityEngine.InputSystem.InputAction.CallbackContext value)
    {
        return;
    }



    

    private void FixedUpdate()
    {
        //print(dashDirection);
        
    }

    private void HandleDash()
    {
        dashDirection = (flyLateral.leftStickAxis.y * transform.forward + flyLateral.leftStickAxis.x * transform.right) * dashSpeed;
        rigidBody.AddForce(dashDirection * Time.deltaTime, ForceMode.Impulse);
    }
    
}
    */