using UnityEngine;

public class Heart : MonoBehaviour
{
    private int _healAmount = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Health>(out Health health))
        {
            health.ApplyHeal(_healAmount);
            Destroy(gameObject);
        }
    }
}
