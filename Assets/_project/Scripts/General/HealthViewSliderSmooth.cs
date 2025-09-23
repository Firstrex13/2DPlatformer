using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthViewSliderSmooth : HealthViewBasic
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fillColor;

    private void Awake()
    {
        Health = GetComponent<Health>();
    }

    public override void UpdateValue()
    {
        StartCoroutine(nameof(ChangeValue));
    }

    private IEnumerator ChangeValue()
    {
        float duration = 1f;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;

            float currentValue = Health.CurrentHealth / Health.MaxValue;

            _slider.value = Mathf.MoveTowards(_slider.value, currentValue, Time.deltaTime);

            _fillColor.color = _gradient.Evaluate(_slider.value);

            yield return null;
        }
    }
}
