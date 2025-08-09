using UnityEngine;

public class EnemyAnimationsStarter : MonoBehaviour
{
    [SerializeField] private EnemyAnimations _enemyAnimations;
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.Hit += _enemyAnimations.PlayHit;
    }

    private void OnDisable()
    {
        _health.Hit -= _enemyAnimations.PlayHit;
    }
}
