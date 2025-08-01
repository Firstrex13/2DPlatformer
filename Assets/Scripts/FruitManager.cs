using TMPro;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
    [SerializeField] private Fruit[] _fruits;

    [SerializeField] private TextMeshProUGUI _text;

    private int _fruitCount = 0;

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
        _text.text = _fruitCount.ToString();
    }
}
