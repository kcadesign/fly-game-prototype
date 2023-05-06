using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMovementInitialise : MonoBehaviour
{
    [Header("References")]
    protected Rigidbody rigidBody;
    protected PlayerControls playerControls;

    protected virtual void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerControls = new PlayerControls();
    }
}
