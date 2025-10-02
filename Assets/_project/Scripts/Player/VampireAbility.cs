using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class VampireAbility : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;

    [SerializeField] private PlayerInput _input;

    [SerializeField] private GameObject _abilityZone;

    [SerializeField] private int _stealLifeStrength;

    [SerializeField] private float _stealLifePeriod;

    [SerializeField] private LayerMask _enemyLayer;

    [SerializeField] private float _abilityRadius = 3f;

    private float _abilityTime = 6f;

    private Transform _transform;

    private Coroutine _stealLifeCorutine;

    [SerializeField] private bool _enemyChecked = false;

    [SerializeField] private Health _enemyHealth;

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

    private void Start()
    {
        _abilityZone.SetActive(false);
    }

    private void Update()
    {
        DetectEnemy();

        if (_enemyChecked)
        {
            if (_stealLifeCorutine == null)
            {
                _stealLifeCorutine = StartCoroutine(StealLife(_enemyHealth));
            }
        }
    }

    private void Activate()
    {
        _abilityZone.SetActive(true);

        StartCoroutine(DeActivate());
    }

    private IEnumerator DeActivate()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_abilityTime);

        yield return waitForSeconds;

        _abilityZone.SetActive(false);
    }

    private void DetectEnemy()
    {
        Enemy nearestEnemy = null;

        float minDistance = Int32.MaxValue;

        var colliders = Physics2D.OverlapCircleAll(_transform.position, _abilityRadius, _enemyLayer);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (Vector3.Distance(_transform.position, colliders[i].transform.position) < minDistance)
            {
                float enemyDistance = Vector3.Distance(_transform.position, colliders[i].transform.position);

                minDistance = enemyDistance;

                if (nearestEnemy = colliders[i].GetComponent<Enemy>())
                {
                    _enemyHealth = nearestEnemy.GetComponent<Health>();

                    _enemyChecked = true;
                }

                if (nearestEnemy == null)
                {
                    _enemyHealth = null;

                    _enemyChecked = false;
                }
            }
        }
    }

    private IEnumerator StealLife(Health health)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_stealLifePeriod);

        while (enabled)
        {
            health.TakeDamage(_stealLifeStrength);

            yield return waitForSeconds;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(_transform.position, _abilityRadius);
    }
}
