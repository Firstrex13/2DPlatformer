using System;
using UnityEngine;

public class EnemyCheck : MonoBehaviour
{
    private bool _enemyDetected = false;

    public bool EnemyDetected => _enemyDetected;

    public Action<Health> Detected;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Health health = enemy.GetComponent<Health>();

            _enemyDetected = true;

            Detected?.Invoke(health);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out _))
        {
            _enemyDetected = false;
        }
    }
}
