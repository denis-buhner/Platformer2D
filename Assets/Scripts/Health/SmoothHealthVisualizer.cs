using System.Collections;
using UnityEngine;

public class SmoothHealthVisualizer : HealthVisualizer
{
    [SerializeField] private float _fillSpeed;

    private float _previousHeath;
    private Coroutine _changeHealthValueRoutine;

    protected override void VisualizeHealth(float health)
    {
        if(_changeHealthValueRoutine != null)
        {
            StopCoroutine(_changeHealthValueRoutine);
            _changeHealthValueRoutine = null;
        }
        
        if(health > _previousHeath)
        {
            _changeHealthValueRoutine = StartCoroutine(IncreaseHealthValue(health));
        }
        else
        {
            _changeHealthValueRoutine = StartCoroutine(DecreaseHealthValue(health));
        }
    }

    public override void Initialize(Health health)
    {
        base.Initialize(health);
        _previousHeath = Health.CurrentHealth;
    }

    private IEnumerator IncreaseHealthValue(float targetValue)
    {
        while (_previousHeath < targetValue)
        {
            float valueStep = Mathf.MoveTowards(_previousHeath, targetValue, Time.deltaTime*_fillSpeed);
            Slider.value = valueStep/Health.MaxHealth;
            TextMeshPro.text = VisualizeText(valueStep);
            _previousHeath = valueStep;
            yield return null;
        }
    }
    private IEnumerator DecreaseHealthValue(float targetValue)
    {
        while (_previousHeath > targetValue)
        {
            float valueStep = Mathf.MoveTowards(_previousHeath, targetValue, Time.deltaTime * _fillSpeed);
            Slider.value = valueStep / Health.MaxHealth;
            TextMeshPro.text = VisualizeText(valueStep);
            _previousHeath = valueStep;
            yield return null;
        }
    }

    protected override string VisualizeText(float health)
    {
        string textToOutput = $"{health.ToString("#.##")} / {Health.MaxHealth}";
        return textToOutput;
    }
}
