using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScoreData : ScriptableObject
{
    public int MaxChaosScore = 100;
    public int CurrentChaosScore;
    public float CurrentTime;

    public void IncreaseScore(int amount)
    {
        CurrentChaosScore += amount;
        CurrentChaosScore = Mathf.Clamp(CurrentChaosScore, 0, MaxChaosScore); // Ensure the score doesn't exceed the maximum value
    }

    public void DecreaseScore(int amount)
    {
        CurrentChaosScore -= amount;
        CurrentChaosScore = Mathf.Clamp(CurrentChaosScore, 0, MaxChaosScore); // Ensure the score doesn't go below zero
    }

    public float GetCurrentScore()
    {
        return CurrentChaosScore;
    }

    public void ResetScore()
    {
        CurrentChaosScore = 0;
    }
}
