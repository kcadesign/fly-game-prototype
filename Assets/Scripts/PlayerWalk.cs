using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    [Header("References")]
    private Rigidbody rigidBody;

    [SerializeField] private float WalkSpeed = 1f;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        HandleWalking();
    }

    private void HandleWalking()
    {
        float forwardInput = Input.GetAxisRaw("Vertical");
        float turnInput = Input.GetAxisRaw("Horizontal");

        Vector3 forwardForce = WalkSpeed * forwardInput * transform.forward;

        transform.Rotate(0f, turnInput, 0f);

        if (forwardForce.magnitude == 0)
        {
            forwardForce = Vector3.zero;
        }
        else
        {
            rigidBody.AddForce(forwardForce, ForceMode.Impulse);
        }
    }

}


