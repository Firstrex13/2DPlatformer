using System;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private int _fruitCount = 0;

    public int FruitCount => _fruitCount;

    public Action CountChanged;

    public void AddFruit()
    {
        _fruitCount++;
        CountChanged?.Invoke();
    }
}
