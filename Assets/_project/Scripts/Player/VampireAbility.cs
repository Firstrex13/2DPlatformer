using System.Collections;
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

    private Coroutine _stealLifeCoroutine;
    private Coroutine _switchOn_OffCoroutine;

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
        if (!_activated)
        {
            if (_switchOn_OffCoroutine != null && _stealLifeCoroutine != null)
            {
                _switchOn_OffCoroutine = null;
                _stealLifeCoroutine = null;
            }
        }
        else
        {
            _stealLifeCoroutine = StartCoroutine(DetectEnemy());
        }
    }

    private void Activate()
    {
        _switchOn_OffCoroutine = StartCoroutine(SwitchOn_Off());
    }

    private IEnumerator SwitchOn_Off()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_abilityTime);

        _abilityZone.SetActive(true);

        _activated = true;

        yield return waitForSeconds;

        _abilityZone.SetActive(false);

        _activated = false;
    }

    private IEnumerator DeActivate()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_abilityTime);

        yield return waitForSeconds;

        _abilityZone.SetActive(false);

        _activated = false;
    }

    private IEnumerator DetectEnemy()
    {
        while (_abilityTime > 0)
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
                _enemyHealth.TakeDamage(_stealLifeStrength);
            }
            else
            {
                _enemyHealth = null;
                _enemyChecked = false;
                _stealLifeCoroutine = null;
            }

            _abilityTime -= Time.deltaTime;

            yield return null;
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
