using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityMultiply : MonoBehaviour
{
    public float gravityMultiplier = 0;

    private Rigidbody rigidBody;

    private FlyLateral flyLateral;
    private FlyUp flyUp;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        flyLateral = GetComponent<FlyLateral>();
        flyUp = GetComponent<FlyUp>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleGravity(flyLateral.leftStickAxis.y, flyLateral.leftStickAxis.x, flyUp.inputValue);
    }

    private void HandleGravity(float forwardInput, float lateralInput, float verticalInput)
    {
        if (forwardInput == 0 && lateralInput == 0 && verticalInput == 0)
        {
            rigidBody.AddForce(Vector3.down * Physics.gravity.magnitude * gravityMultiplier, ForceMode.Acceleration);
        }
    }
}
