using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private Health _health;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<ICollectable>(out _))
        {
            if (collision.TryGetComponent(out Fruit fruit))
            {
                fruit.Collect();
                _counter.AddFruit();
            }
            else if (collision.TryGetComponent(out Heart heart))
            {
                heart.Heal(_health);
                heart.DestroyHeart();
            }
        }
    }
}
