using System;
using System.Collections;
using UnityEngine;

[SelectionBase]
public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxValue;
    [SerializeField] private float _currentValue;
    [SerializeField] private float _changeHealthPeriod;

    public event Action Hit;
    public event Action Healed;
    public event Action<GameObject> Died;

    public float CurrentHealth => _currentValue;
    public int MaxValue => _maxValue;

    private void Start()
    {
        _currentValue = _maxValue;
    }

    public void TakeDamage(int damage)
    {
        if (_currentValue > 0)
        {
            if (damage < 0)
            {
                damage = 0;
            }

            if (damage > 0)
            {
                _currentValue -= damage;

                if (_currentValue <= 0)
                {
                    _currentValue = 0;
                    Died?.Invoke(gameObject);
                }

                Hit?.Invoke();
            }
        }
    }

    public void ApplyHeal(int healAmount)
    {
        if (healAmount < 0)
        {
            healAmount = 0;
        }

        if (healAmount > 0)
        {
            _currentValue += healAmount;

            if (_currentValue >= _maxValue)
            {
                _currentValue = _maxValue;
            }

            Healed?.Invoke();
        }
    }

    public void HealSmooth()
    {
        Debug.Log("Лечусь.");
    }

    public IEnumerator DamageSmooth(int strength)
    {
        float time = 0;

        while (time < _changeHealthPeriod)
        {
            time += Time.deltaTime;

            if (time > _changeHealthPeriod)
            {
                time = 0;

                TakeDamage(strength);

                yield return null;
            }
        }
    }
}
