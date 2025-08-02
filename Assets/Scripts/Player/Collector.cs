using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Fruit>(out Fruit fruit))
        {
            fruit.Collect();
            _counter.AddFruit();
        }
    }
}
