using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthVisualizer : MonoBehaviour
{
    [SerializeField] protected Slider Slider;
    [SerializeField] protected TMP_Text TextMeshPro;

    protected Health Health;

    public virtual void Initialize(Health health)
    {
        Health = health;
        Health.HealthUpdate += VisualizeHealth;
    }

    private void OnEnable()
    {
        if(Health != null)
            Health.HealthUpdate += VisualizeHealth;
    }

    private void OnDisable()
    {
        Health.HealthUpdate -= VisualizeHealth;
    }

    protected virtual void VisualizeHealth(float health)
    {
        Slider.value = health/Health.MaxHealth;
        TextMeshPro.text = VisualizeText(health);
    }

    protected virtual string VisualizeText(float health)
    {
        string textToOutput = $"{health} / {Health.MaxHealth}";
        return textToOutput;
    }
}
