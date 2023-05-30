using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMovementInitialise : MonoBehaviour
{
    [Header("References")]
    protected Rigidbody rigidBody;
    protected HandlePlayerInput _handlePlayerInput;

    protected virtual void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        _handlePlayerInput = GetComponent<HandlePlayerInput>();
    }
}
