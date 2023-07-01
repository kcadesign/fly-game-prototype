using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleInGameUI : MonoBehaviour
{
    public GameObject InGameUI;

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

    private void HandleUIState_OnGamePaused(bool isPaused)
    {
        if (isPaused)
        {
            InGameUI.SetActive(false);
        }
        else if (!isPaused)
        {
            InGameUI.SetActive(true);
        }
    }

    private void HandlePlayerHealth_OnHealthChange(int currentHealth)
    {
        // If the players health is <= zero then show lose game UI

        if (currentHealth <= 0)
        {
            InGameUI.SetActive(false);
        }
    }

    private void DataManager_OnScoreReference(int currentScore)
    {
        // If score is >= max chaos then show win game UI

        if (currentScore >= 100)
        {
            InGameUI.SetActive(false);
        }
    }
}
