using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHoverState : PlayerBaseState
{
    public PlayerHoverState(PlayerStateMachine currentContext, PlayerStateFactory playerStatefactory)
        : base(currentContext, playerStatefactory)
    {

    }


    public override void EnterState() { }

    public override void FixedUpdateState() { }

    public override void ExitState() { }

    public override void CheckSwitchStates() { }

    public override void InitialiseSubState() { }
}
