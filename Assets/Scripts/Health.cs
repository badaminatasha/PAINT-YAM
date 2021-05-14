using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Serializable]
    public class HealthChangeEvent: UnityEvent<float> { }

    public float MaxHealth { get { return startHealth; } }
    public float CurrentHealth { get { return currentHealth; } }

    [SerializeField] float startHealth;
    [SerializeField] HealthChangeEvent OnDeath;
    [SerializeField] HealthChangeEvent OnHealthChange;

    float currentHealth;

    private void Start()
    {
        currentHealth = MaxHealth;
    }

    public void DecreaseHealthBy(float amount)
    {
        currentHealth = Mathf.Max(0f, currentHealth - amount);
        OnHealthChange?.Invoke(currentHealth);
        if (currentHealth == 0f)
            OnDeath?.Invoke(0f);
    }
}
