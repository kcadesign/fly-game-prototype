using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void OnEnable()
    {
        HandlePlayerHealth.OnHealthChange += HandlePlayerHealth_OnHealthChange;
        DataManager.OnScoreReference += DataManager_OnScoreReference;
        HandleUIState.OnGamePaused += HandleUIState_OnGamePaused;
    }

    private void OnDisable()
    {
        HandlePlayerHealth.OnHealthChange -= HandlePlayerHealth_OnHealthChange;
        DataManager.OnScoreReference -= DataManager_OnScoreReference;
        HandleUIState.OnGamePaused -= HandleUIState_OnGamePaused;
    }

    private void HandlePlayerHealth_OnHealthChange(int currentHealth)
    {
        if(currentHealth <= 0)
        {
            Time.timeScale = 0;
        }
    }

    private void DataManager_OnScoreReference(int currentScore)
    {
        if (currentScore >=100)
        {
            Time.timeScale = 0;
        }
    }
    
    private void HandleUIState_OnGamePaused(bool isPaused)
    {
        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else if (!isPaused)
        {
            Time.timeScale = 1;
        }
    }
}
