using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SolvableSystem : ScriptableObject
{
    public int ElementsNeededForSolve;
    public int CurrentActivatedElements;

    public int SystemPointValue;

    public bool Solved = false;

    public void IncrementElements()
    {
        CurrentActivatedElements ++;
        CurrentActivatedElements = Mathf.Clamp(CurrentActivatedElements, 0, ElementsNeededForSolve);
    }

    public float GetCurrentActivatedElements()
    {
        return CurrentActivatedElements;
    }

    public void ResetElements()
    {
        CurrentActivatedElements = 0;
    }

}
