using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HandleUIState : MonoBehaviour
{
    protected HandlePlayerInput _handlePlayerInput;

    public delegate void GamePaused(bool isPaused);
    public static event GamePaused OnGamePaused;

    public GameObject WinPanel;
    public TextMeshProUGUI FinishTimeText;
    private float _finishTime;
    private int minutes = 0;
    private int seconds = 0;

    public GameObject LosePanel;

    public GameObject PausePanel;
    private bool _isPaused = false;

    private bool _previousButtonState;

    private void Awake()
    {
        _handlePlayerInput = GetComponent<HandlePlayerInput>();

        WinPanel.SetActive(false);
        LosePanel.SetActive(false);
    }

    private void OnEnable()
    {
        HandlePlayerHealth.OnHealthChange += HandlePlayerHealth_OnHealthChange;
        DataManager.OnScoreReference += DataManager_OnScoreReference;
        HandleTimer.OnTimeReference += HandleTimer_OnTimeReference;
    }

    private void OnDisable()
    {
        HandlePlayerHealth.OnHealthChange -= HandlePlayerHealth_OnHealthChange;
        DataManager.OnScoreReference -= DataManager_OnScoreReference;
        HandleTimer.OnTimeReference -= HandleTimer_OnTimeReference;
    }

    private void Update()
    {
        HandlePauseLogic();
    }

    private void HandlePauseLogic()
    {
        bool currentButtonState = _handlePlayerInput.StartButtonPressed;

        if (currentButtonState && !_previousButtonState)
        {
            // Button was just pressed, toggle the pause state
            _isPaused = !_isPaused;
            OnGamePaused?.Invoke(_isPaused);
        }

        // Update the previous button state
        _previousButtonState = currentButtonState;

        // Set the pause panel active state based on the pause state
        PausePanel.SetActive(_isPaused);
    }


    private void HandlePlayerHealth_OnHealthChange(int currentHealth)
    {
        // If the players health is <= to zero then show lose game UI

        if(currentHealth <= 0)
        {
            LosePanel.SetActive(true);
        }
    }
    
    private void DataManager_OnScoreReference(int currentScore)
    {
        // If score is >= to max chaos then show win game UI

        if(currentScore >= 100)
        {
            WinPanel.SetActive(true);

            print(_finishTime);

            minutes = Mathf.FloorToInt(_finishTime / 60f);
            seconds = Mathf.FloorToInt(_finishTime % 60f);

            // Update the timer text
            FinishTimeText.text = minutes.ToString("D2") + ":" + seconds.ToString("D2");
        }
    }
    private void HandleTimer_OnTimeReference(float currentTime)
    {
        _finishTime = currentTime;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
