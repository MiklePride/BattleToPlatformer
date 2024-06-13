using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : Bar
{
    [SerializeField] private Slider _health;
    [SerializeField, Min(0.01f)] private float _durationDrow = 0.2f;

    private Coroutine _drawCoroutine;

    protected override void OnHealthChenge(float health, float maxHealth)
    {
        float healthAsPercentage = Mathf.Clamp01(health / maxHealth);

        if (_drawCoroutine != null)
            StopCoroutine(_drawCoroutine);

        _drawCoroutine = StartCoroutine(DrawHealth(healthAsPercentage));
    }

    private IEnumerator DrawHealth(float targetValue)
    {
        while (_health.value != targetValue)
        {
            _health.value = Mathf.MoveTowards(_health.value, targetValue, _durationDrow * Time.deltaTime);

            yield return null;
        }
    }
}
