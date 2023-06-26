using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandleTimerUI : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private int minutes = 0;
    private int seconds = 0;

    private void OnEnable()
    {
        HandleTimer.OnTimeReference += HandleTimer_OnTimeReference;
    }
    private void OnDisable()
    {
        HandleTimer.OnTimeReference -= HandleTimer_OnTimeReference;
    }

    private void HandleTimer_OnTimeReference(float currentTime)
    {
        // Calculate minutes and seconds
        minutes = Mathf.FloorToInt(currentTime / 60f);
        seconds = Mathf.FloorToInt(currentTime % 60f);

        // Update the timer text
        timerText.text = minutes.ToString("D2") + ":" + seconds.ToString("D2");
    }
}
