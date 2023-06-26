using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleObjectInteraction : MonoBehaviour
{
    public delegate void TriggerEvent(ScriptableObject solvableSystem);
    public static event TriggerEvent OnTrigger;

    public ScriptableObject SolvableSystem;

    private bool _isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (_isTriggered)
        {
            return;
        }
        if (!other.gameObject.CompareTag("Human"))
        {
            return;
        }

        OnTrigger?.Invoke(SolvableSystem);
        _isTriggered = true;
    }
}