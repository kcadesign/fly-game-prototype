using UnityEngine;

public abstract class PlayerBaseState
{

    protected virtual void Awake()
    {

    }

    public abstract void EnterState(PlayerStateManager playerState);

    public abstract void UpdateState(PlayerStateManager playerState);

    public abstract void OnCollisionEnter(PlayerStateManager playerState, Collision collision);
}
