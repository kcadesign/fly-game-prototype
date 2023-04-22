using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlyUp : MonoBehaviour
{
    private Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleFlyUp(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rigidBody.AddForce(50 * Time.deltaTime * Vector3.up, ForceMode.Impulse);
        }

    }
}
