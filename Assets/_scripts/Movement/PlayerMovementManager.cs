using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementManager : MonoBehaviour
{
    private FlyB _flyScript;
    private RotateLook _rotateLookScript;
    private Walk _walkScript;
    private HandleSurfaceStick _stickScript;
    private Boost _boostScript;

    public enum PlayerState
    {
        Idle,
        Flying,
        Sticking
    }

    public PlayerState CurrentState;

    private void Awake()
    {
        _flyScript = GetComponent<FlyB>();
        _rotateLookScript = GetComponent<RotateLook>();
        _walkScript = GetComponent<Walk>();
        _stickScript = GetComponent<HandleSurfaceStick>();
        _boostScript = GetComponent<Boost>();
    }

    private void Start()
    {
        _flyScript.enabled = true;
        _rotateLookScript.enabled = true;
        _walkScript.enabled = false;
        _stickScript.enabled = true;
        _boostScript.enabled = true;
    }

    private void Update()
    {
        HandleState();
    }

    public void ChangeState(PlayerState newState)
    {
        CurrentState = newState;
    }

    public void HandleState()
    {
        if (_stickScript.Sticking)
        {
            ChangeState(PlayerState.Sticking);
        }
        else if (!_stickScript.Sticking)
        {
            ChangeState(PlayerState.Flying);
        }

        switch (CurrentState)
        {
            case PlayerState.Idle:
                _flyScript.enabled = true;
                _rotateLookScript.enabled = true;
                _walkScript.enabled = false;
                _stickScript.enabled = true;
                _boostScript.enabled = true;
                break;
            case PlayerState.Flying:
                _flyScript.enabled = true;
                _walkScript.enabled = false;
                _boostScript.enabled = true;
                break;
            case PlayerState.Sticking:
                _flyScript.enabled = false;
                _walkScript.enabled = true;
                _boostScript.enabled = false;
                break;
            default:
                _flyScript.enabled = true;
                _rotateLookScript.enabled = true;
                _walkScript.enabled = false;
                _stickScript.enabled = true;
                _boostScript.enabled = true;
                break;
        }
    }

}
