using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandedState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager playerState)
    {
        Debug.Log("Hello from the landed state");
    }

    public override void UpdateState(PlayerStateManager playerState)
    {

    }

    public override void OnCollisionEnter(PlayerStateManager playerState, Collision collision)
    {

    }
}
