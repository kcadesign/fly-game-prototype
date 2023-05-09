using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHoverState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager playerState)
    {
        Debug.Log("Hello from the hover state");
    }

    public override void UpdateState(PlayerStateManager playerState)
    {

    }

    public override void OnCollisionEnter(PlayerStateManager playerState, Collision collision)
    {

    }
}
