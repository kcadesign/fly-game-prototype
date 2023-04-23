using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerFly : MonoBehaviour
{
    [Header("References")]
    //private Rigidbody rigidBody;
    private PlayerControls playerControls;

    /*
    [Header("Flying Values")]
    [SerializeField] private float lateralFlySpeed = 5f;
    [SerializeField] private float verticalFlySpeed = 5f;
    [SerializeField] private float verticalLiftValue = 0.5f;
    */
    private Vector2 inputValue;

    /*
    [Header("Physical Values")]
    [SerializeField] private float gravityMultiplier = 1f;
    
    [Header("Input")]
    private float forwardInput;
    private float lateralInput;
    private float verticalInput;
    */
    void Start()
    {
        //rigidBody = GetComponent<Rigidbody>();
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

    /*
    void Update()
    {
        
        forwardInput = Input.GetAxisRaw("Vertical");
        lateralInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Jump");
        
    }
    */

    void FixedUpdate()
    {
        Debug.Log(inputValue);


        //HandleLateralMovement(forwardInput, lateralInput);
        //HandleVerticalMovement(verticalInput);
        //HandleGravity(forwardInput, lateralInput, verticalInput);
    }

    private void Move_performed(InputAction.CallbackContext value)
    {
        inputValue = value.ReadValue<Vector2>();
    }

    private void Move_Cancelled(InputAction.CallbackContext value)
    {
        inputValue = Vector2.zero;
    }

    /*
    private void HandleLateralMovement(float forwardInput, float lateralInput)
    {
        Vector3 movementDirection = (forwardInput * transform.forward + lateralInput * transform.right).normalized;
        Vector3 movementForce = lateralFlySpeed * Time.deltaTime * movementDirection + VerticalLift();

        if (forwardInput != 0 || lateralInput != 0)
        {
            rigidBody.AddForce(movementForce, ForceMode.Impulse);
        }
    }
    */
    /*
    public void HandleVerticalMovement(float verticalInput)
    {
        Vector3 verticalForce = verticalFlySpeed * Time.deltaTime * verticalInput * Vector3.up;

        
        if (verticalInput != 0)
        {
            rigidBody.AddForce(verticalForce, ForceMode.Impulse);
        }
        
    }
    
    private void HandleGravity(float forwardInput, float lateralInput, float verticalInput)
    {
        if (forwardInput == 0 && lateralInput == 0 && verticalInput == 0)
        {
            rigidBody.AddForce(Vector3.down * Physics.gravity.magnitude * gravityMultiplier, ForceMode.Acceleration);
        }
    }
    

    private Vector3 VerticalLift()
    {
        return new Vector3(0, verticalLiftValue, 0);
    }
    */
}
