using System;
using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    [SerializeField] private float _maxHealth;
    private float _health;

    public float CurrentHealth => _health;
    public float MaxHealth => _maxHealth;
    public event Action<float> HealthUpdate;
    public event Action IsDead;

    private void Start()
    {
        _health = _maxHealth;
        HealthUpdate?.Invoke(_health);
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            return;

        _health -= damage;

        if(_health <= 0)
        {
            _health = 0;
            IsDead?.Invoke();
        }

        HealthUpdate?.Invoke(_health);
    }

    public void TakeHeal(float heal)
    {
        if (heal < 0)
            return;

        _health += heal;

        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }

        HealthUpdate?.Invoke(_health);
    }
}
