using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleBarUI : MonoBehaviour
{
    public Image BarValueMask;
    private float _currentFill;
    private float _maxFill = 100;

    private void OnEnable()
    {
        DataManager.OnScoreReference += DataManager_OnScoreReference;
    }

    private void OnDisable()
    {
        DataManager.OnScoreReference -= DataManager_OnScoreReference;
    }
    private void DataManager_OnScoreReference(int currentScore)
    {
        _currentFill = currentScore;
        GetSetCurrentFill();
    }

    private void GetSetCurrentFill() 
    {
        float CurrentFillPercentage = _currentFill / _maxFill;
        BarValueMask.fillAmount = CurrentFillPercentage;
    } 
}