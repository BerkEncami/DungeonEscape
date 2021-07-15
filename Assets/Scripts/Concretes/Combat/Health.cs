using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    [SerializeField]
    int MaxHealth = 3;

    int _currentHealth;

    public event Action<int ,int> OnHealthChanged;
    public event Action OnDead;

    public int CurrentHealth => _currentHealth;

    public bool IsDead => _currentHealth < 1;

    private void Awake()
    {
        _currentHealth = MaxHealth;
    }
    public void TakeHit(IAttacker attacker)
    {
        if (IsDead) return;
        
        _currentHealth -= attacker.Damage;
        OnHealthChanged?.Invoke(CurrentHealth,MaxHealth);

        if (IsDead) OnDead?.Invoke();
    }
}
