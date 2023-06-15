using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePlayerHealth : MonoBehaviour
{
    public HealthSystem PlayerHealth;
    [SerializeField] private int _maxHealth = 5;
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
        _currentHealth = PlayerHealth.GetHealth();
    }

    private void OnCollisionEnter(Collision collision)
    {
        print($"Collided with {collision.gameObject.tag}");

        if (collision.gameObject.CompareTag("Human"))
        {
            PlayerHealth.Damage(1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print($"Collided with {other.gameObject.tag}");

        if (other.gameObject.CompareTag("Human"))
        {
            PlayerHealth.Damage(1);
        }
    }
}
