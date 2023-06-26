using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleHealthUI : MonoBehaviour
{
    private GameObject _healthIconContainer;
    public GameObject HealthIcon;

    private int _currentHealth;

    private void Awake()
    {
        _healthIconContainer = this.gameObject;
    }

    private void OnEnable()
    {
        HandlePlayerHealth.OnHealthChange += HandlePlayerHealth_OnHealthChange;
    }

    private void OnDisable()
    {
        HandlePlayerHealth.OnHealthChange -= HandlePlayerHealth_OnHealthChange;

    }

    private void HandlePlayerHealth_OnHealthChange(int currentHealth)
    {
        _currentHealth = currentHealth;
        UpdateHealthUI();
    }

    void Start()
    {
        InitialiseHealthIcons();
    }

    void Update()
    {
        
    }

    private void InitialiseHealthIcons()
    {
        Vector3 healthIconPosition = _healthIconContainer.transform.position;
        Quaternion healthIconRotation = _healthIconContainer.transform.rotation;

        for (int i = 0; i < _currentHealth; i++)
        {
            Instantiate(HealthIcon, healthIconPosition, healthIconRotation, _healthIconContainer.transform);
        }
    }

    private void UpdateHealthUI()
    {
        if (_currentHealth < _healthIconContainer.transform.childCount)
        {
            for (int i = _currentHealth; i < _healthIconContainer.transform.childCount; i++)
            {
                _healthIconContainer.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}

