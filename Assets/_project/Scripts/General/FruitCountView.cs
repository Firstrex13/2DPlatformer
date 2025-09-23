using TMPro;
using UnityEngine;

public class FruitCountView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _text;

    public void Initialize(Counter counter)
    {
        _counter = counter;
    }

    private void OnEnable()
    {
        _counter.CountChanged += UpdateCountNumber;
    }

    private void OnDisable()
    {
        _counter.CountChanged -= UpdateCountNumber;
    }

    private void UpdateCountNumber()
    {
        _text.text = _counter.FruitCount.ToString();
    }
}
