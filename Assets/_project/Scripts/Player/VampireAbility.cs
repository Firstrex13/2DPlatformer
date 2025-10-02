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

    [SerializeField] private bool _activated;

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
        if (_activated)
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
    }

    private void Activate()
    {
        _abilityZone.SetActive(true);

        _activated = true;

        StartCoroutine(DeActivate());
    }

    private IEnumerator DeActivate()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_abilityTime);

        yield return waitForSeconds;

        _abilityZone.SetActive(false);

        _activated = false;
    }

    private void DetectEnemy()
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
            _enemyChecked = _enemyHealth != null;
        }
        else
        {
            _enemyHealth = null;
            _enemyChecked = false;
            _stealLifeCorutine = null;
        }
    }

    private IEnumerator StealLife(Health health)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_stealLifePeriod);

        while (_enemyHealth != null)
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
