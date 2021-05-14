using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerHealthCallbacks : MonoBehaviour
{
    Slider healthSlider;

    private void Start()
    {
        healthSlider = FindObjectOfType<Slider>();
        healthSlider.maxValue = GetComponent<Health>().MaxHealth;
        healthSlider.value = healthSlider.maxValue;
    }

    public void SetHealthTo(float amount)
    {
        healthSlider.value = amount;
    }
}
