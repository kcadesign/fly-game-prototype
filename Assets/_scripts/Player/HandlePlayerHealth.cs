using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePlayerHealth : MonoBehaviour
{
    public HealthSystem PlayerHealth;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;

    private void Awake()
    {
        PlayerHealth = new HealthSystem(_maxHealth);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
