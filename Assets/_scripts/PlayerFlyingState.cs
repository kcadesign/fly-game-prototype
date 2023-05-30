using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlyingState : PlayerBaseState
{
    public PlayerFlyingState(PlayerStateMachine currentContext, PlayerStateFactory playerStatefactory)
        : base (currentContext, playerStatefactory)
    {

    }

    public override void EnterState() 
    {
        Debug.Log("Hello from the flying state!");
    
    }

    public override void FixedUpdateState() { }

    public override void ExitState(){}

    public override void CheckSwitchStates()
    {
        if(_ctx.LeftStickAxis.magnitude == 0)
        {

        }
    }

    public override void InitialiseSubState(){}
}
