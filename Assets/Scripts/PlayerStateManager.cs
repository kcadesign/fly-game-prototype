using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    protected Rigidbody rigidBody;
    protected PlayerControls playerControls;

    PlayerBaseState currentState;
    public PlayerFlyingState FlyingState = new PlayerFlyingState();
    public PlayerHoverState HoverState = new PlayerHoverState();
    public PlayerLandedState landedState = new PlayerLandedState();


    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerControls = new PlayerControls();
    }

    void Start()
    {
        currentState = FlyingState;

        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }
}
