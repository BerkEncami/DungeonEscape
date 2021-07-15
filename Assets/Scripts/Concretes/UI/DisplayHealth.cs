using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    Image _healthImage;
    IHealth _helath;
    private void Awake()
    {
        _healthImage = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _helath = FindObjectOfType<PlayerController>().GetComponent<IHealth>();
        _helath.OnHealthChanged += HandleHealthChanged;
    }

    private void OnDisable()
    {
        _helath.OnHealthChanged -= HandleHealthChanged;
        _healthImage.fillAmount = 1f;
    }
    private void HandleHealthChanged(int currentHealth, int maxHealth)
    {
    
        _healthImage.fillAmount = (float)currentHealth / (float)maxHealth;

    }


}
