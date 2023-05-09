using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlyingState : PlayerBaseState
{
    protected Rigidbody rigidBody;


    

    public override void EnterState(PlayerStateManager playerState)
    {
        Debug.Log("Hello from the flying state");
        rigidBody = playerState.GetComponent<Rigidbody>();

    }

    public override void UpdateState(PlayerStateManager playerState)
    {

    }

    public override void OnCollisionEnter(PlayerStateManager playerState, Collision collision)
    {

    }
}
