using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public delegate void ScoreReference(int currentScore);
    public static event ScoreReference OnScoreReference;

    public ScoreData ScoreData;

    private void Awake()
    {
        ScoreData.ResetScore();
    }

    private void OnEnable()
    {
        HandleSolveCondition.OnPointCreation += HandleSolveCondition_OnPointCreation;
        HandleTimer.OnTimeReference += HandleTimer_OnTimeReference;
    }


    private void OnDisable()
    {
        HandleSolveCondition.OnPointCreation -= HandleSolveCondition_OnPointCreation;
        HandleTimer.OnTimeReference -= HandleTimer_OnTimeReference;

    }
    private void HandleSolveCondition_OnPointCreation(int pointValue)
    {
        print($"Add {pointValue} points!");
        ScoreData.IncreaseScore(pointValue);

        OnScoreReference?.Invoke(ScoreData.CurrentChaosScore);
    }

    private void HandleTimer_OnTimeReference(float currentTime)
    {
        ScoreData.CurrentTime = currentTime;
    }

}
