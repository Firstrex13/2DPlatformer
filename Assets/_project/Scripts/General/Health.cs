using System;
using UnityEngine;

[SelectionBase]
public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxValue;
    [SerializeField] private int _currentValue;

    public event Action ChangedDown;
    public event Action ChangedUp;
    public event Action<GameObject> Died;

    private void Start()
    {
        _currentValue = _maxValue;
    }

    public void TakeDamage(int damage)
    {
        if(damage < 0)
        {
            damage = 0;
        }

        _currentValue -= damage;

        ChangedDown?.Invoke();

        if(_currentValue <= 0)
        {
            Died?.Invoke(gameObject);
        }
    }

    public void ApplyHeal(int healAmount)
    {
        if (healAmount < 0)
        {
            healAmount = 0;
        }

        _currentValue += healAmount;

        ChangedUp?.Invoke();

        if(_currentValue >= _maxValue)
        {
            _currentValue = _maxValue;
        }
    }
}


