using UnityEngine;

[RequireComponent(typeof(HealthVisualizer), typeof(Health))]
public class HealthHandler : MonoBehaviour, IDamageable
{
    [Header("components")]
    [SerializeField] private HealthVisualizer _healthVisualizer;

    private Health _health;

    private void OnEnable()
    {
        if (_healthVisualizer == null)
            _healthVisualizer = GetComponent<HealthVisualizer>();

        _health = GetComponent<Health>();

        _healthVisualizer.Initialize(_health);
    }

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
    }

    public void Heal(float heal)
    {
        _health.TakeHeal(heal);
    }
}
