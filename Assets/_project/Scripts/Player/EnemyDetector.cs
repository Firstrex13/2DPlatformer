using System;
using System.Collections;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayer;

    [SerializeField] private float _abilityRadius = 1.5f;

    [SerializeField] private Health _enemyHealth;

    [SerializeField] private PlayerInput _input;

    private float _abilityTime = 6f;

    private Transform _transform;

    private Coroutine _detectEnemyCoroutine;

    private bool _enemyDetected;

    public Health EnemyHealth => _enemyHealth;

    public event Action<Health> EnemyHealthDetected;

    public bool EnemyDetected => _enemyDetected;

    public void Initialize(PlayerInput input)
    {
        _input = input;
    }

    private void Awake()
    {
        _transform = transform;
    }

    private void OnEnable()
    {
        _input.AbilityButtonPressed += Activate;
    }

    private void OnDisable()
    {
        _input.AbilityButtonPressed -= Activate;
    }

    private void Activate()
    {
        if(_detectEnemyCoroutine != null)
        {
            StopCoroutine( _detectEnemyCoroutine );
        }

       _detectEnemyCoroutine = StartCoroutine(DetectEnemy());
    }

    private IEnumerator DetectEnemy()
    {
        float timer = 0;

        while (timer < _abilityTime)
        {
            float minDistance = float.MaxValue;

            Enemy nearestEnemy = null;

            var colliders = Physics2D.OverlapCircleAll(_transform.position, _abilityRadius, _enemyLayer);

            for (int i = 0; i < colliders.Length; i++)
            {
                float distanceSquared = Vector3.SqrMagnitude((_transform.position - colliders[i].transform.position));

                if (distanceSquared < minDistance)
                {
                    if (colliders[i].TryGetComponent<Enemy>(out var currentEnemy))
                    {
                        minDistance = distanceSquared;
                        nearestEnemy = currentEnemy;
                    }
                }
            }

            if (nearestEnemy != null)
            {
                _enemyHealth = nearestEnemy.GetComponent<Health>();
                _enemyDetected = true;
                EnemyHealthDetected?.Invoke(_enemyHealth);
            }
            else
            {
                _enemyHealth = null;
                _enemyDetected = false;
            }

            timer += Time.deltaTime;

            yield return null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(_transform.position, _abilityRadius);
    }
}
