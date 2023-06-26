using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleSolveCondition : MonoBehaviour
{
    public delegate void PointCreation(int pointValue);
    public static event PointCreation OnPointCreation;

    public SolvableSystem SolvableSystem;

    private bool _solved = false;

    private int _pointValue;

    private void Awake()
    {
        SolvableSystem.ResetElements();
        _pointValue = SolvableSystem.SystemPointValue;
    }

    private void OnEnable()
    {
        HandleObjectInteraction.OnTrigger += HandleObjectInteraction_OnTrigger;
    }

    private void OnDisable()
    {
        HandleObjectInteraction.OnTrigger -= HandleObjectInteraction_OnTrigger;
    }

    private void HandleObjectInteraction_OnTrigger(ScriptableObject solvableSystem)
    {
        print($"Key: {solvableSystem} / Lock: {SolvableSystem}");
        if(solvableSystem == SolvableSystem)
        {
            AddOne();
            print($"{SolvableSystem.name} has {SolvableSystem.GetCurrentActivatedElements()} of {SolvableSystem.ElementsNeededForSolve} activated elements");
        }
    }

    public void AddOne()
    {
        if (!_solved)
        {
            SolvableSystem.IncrementElements();

            if (SolvableSystem.CurrentActivatedElements >= SolvableSystem.ElementsNeededForSolve)
            {
                _solved = true;
                // Trigger the solved event with the system identifier
                OnPointCreation?.Invoke(_pointValue);
            }
        }
    }
}
