using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePlayerHealth : MonoBehaviour
{
    public delegate void PlayerHealthChange(int currentHealth);
    public static event PlayerHealthChange OnHealthChange;

    public HealthSystem PlayerHealth;

    [SerializeField] private int _maxHealth = 5;
    private int _currentHealth;

    private void Awake()
    {
        PlayerHealth = new HealthSystem(_maxHealth);
        _currentHealth = PlayerHealth.GetHealth();

        OnHealthChange?.Invoke(PlayerHealth.GetHealth());
    }

    void Update()
    {
        _currentHealth = PlayerHealth.GetHealth();
    }

    private void OnTriggerEnter(Collider other)
    {
        //print($"Player collided with {other.gameObject.tag}");

        if (other.gameObject.CompareTag("Human"))
        {
            PlayerHealth.Damage(1);
            OnHealthChange?.Invoke(PlayerHealth.GetHealth());

            //print($"Player health is: {PlayerHealth.GetHealth()}");
        }
    }
}
