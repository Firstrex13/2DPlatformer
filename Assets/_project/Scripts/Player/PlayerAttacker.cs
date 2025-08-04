using System.Collections;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private int _damageValue = 1;

    private int _delay = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<EnemyDetector>(out EnemyDetector enemy))
        {
            Health health = enemy.GetComponent<Health>();
            EnemyAnimations animations = enemy.GetComponentInChildren <EnemyAnimations>();

            StartCoroutine(ApplyDamage(health));
            animations.PlayHit();
        }
    }

    private IEnumerator ApplyDamage(Health health)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_delay);

        health.TakeDamage(_damageValue);   
        
        yield return waitForSeconds;
    }
}
