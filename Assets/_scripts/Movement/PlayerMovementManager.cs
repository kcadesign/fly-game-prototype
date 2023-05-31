using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementManager : MonoBehaviour
{
    private FlyB _flyScript;
    private Hover _hoverScript;
    private RotateLook _rotateLookScript;
    private Walk _walkScript;
    private HandleSurfaceStick _stickScript;
    //private GravityMultiply _gravityScript;
    private Boost _boostScript;

    private void Awake()
    {
        _flyScript = GetComponent<FlyB>();
        _hoverScript = GetComponent<Hover>();
        _rotateLookScript = GetComponent<RotateLook>();
        _walkScript = GetComponent<Walk>();
        _stickScript = GetComponent<HandleSurfaceStick>();
        //_gravityScript = GetComponent<GravityMultiply>();
        _boostScript = GetComponent<Boost>();
    }

    private void Start()
    {
        _flyScript.enabled = true;
        _hoverScript.enabled = true;
        _rotateLookScript.enabled = true;
        _walkScript.enabled = false;
        _stickScript.enabled = true;
        //_gravityScript.enabled = true;
        _boostScript.enabled = true;
    }

    private void Update()
    {
        if (_stickScript.Sticking)
        {
            _flyScript.enabled = false;
            _hoverScript.enabled = false;
            _rotateLookScript.enabled = false;
            //_gravityScript.enabled = false;
            _walkScript.enabled = true;
            _boostScript.enabled = false;
        }
        else if (!_stickScript.Sticking)
        {
            _flyScript.enabled = true;
            _hoverScript.enabled = true;
            _rotateLookScript.enabled = true;
            //_gravityScript.enabled = true;
            _walkScript.enabled = false;
            _boostScript.enabled = true;
        }
    }




}
