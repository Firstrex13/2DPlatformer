using System;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private Fruit[] _fruits;

    private int _fruitCount = 0;

    public Action CountChanged;

    private void OnEnable()
    {
        foreach (var fruit in _fruits)
        {
            fruit.PickedUp += AddFruit;
        }
    }

    private void OnDisable()
    {
        foreach (var fruit in _fruits)
        {
            fruit.PickedUp -= AddFruit;
        }
    }

    private void AddFruit()
    {
        _fruitCount++;
        CountChanged?.Invoke();
    }

    public int GetCount()
    {
        return _fruitCount;
    }
}
