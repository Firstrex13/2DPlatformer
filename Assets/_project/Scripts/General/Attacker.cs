using System.Collections;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private int _damageValue = 1;

    private int _delay = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamageable>(out IDamageable enemy))
        {
            StartCoroutine(DealDamage(enemy));
        }
    }

    private IEnumerator DealDamage(IDamageable damageable)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_delay);

        damageable.TakeDamage(_damageValue);

        yield return waitForSeconds;
    }
}
