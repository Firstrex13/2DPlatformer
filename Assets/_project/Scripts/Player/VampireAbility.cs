using System.Collections;
using UnityEngine;

public class VampireAbility : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;

    [SerializeField] private PlayerInput _input;

    [SerializeField] private GameObject _abilityZone;

    [SerializeField] private int _stealLifeStrength;

    [SerializeField] private float _stealLifePeriod = 1f;

    [SerializeField] private EnemyDetector _enemyDetector;

    private float _abilityTime = 6f;

    private Coroutine _stealLifeCoroutine;

    private Coroutine _switchOn_OffCoroutine;

    private Coroutine _reloadCoroutine;

    private bool _isReady = true;

    private bool _isActivated;

    public void Initialize(PlayerInput input)
    {
        _input = input;
    }

    private void OnEnable()
    {
        _input.AbilityButtonPressed += Activate;
        _enemyDetector.EnemyHealthDetected += VampireAttack;
    }

    private void OnDisable()
    {
        _input.AbilityButtonPressed -= Activate;
        _enemyDetector.EnemyHealthDetected -= VampireAttack;
    }

    private void Start()
    {
        _abilityZone.SetActive(false);
        _isActivated = false;
    }

    private void Activate()
    {
        if (!_isActivated)
        {
            if (_switchOn_OffCoroutine != null)
            {
                StopCoroutine(_switchOn_OffCoroutine);
            }

            _switchOn_OffCoroutine = StartCoroutine(SwitchOn_Off());

            _isActivated = true;
        }
    }

    private IEnumerator SwitchOn_Off()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_abilityTime);

        _abilityZone.SetActive(true);

        yield return waitForSeconds;

        _abilityZone.SetActive(false);

        _isActivated = false;
    }

    private void VampireAttack(Health health)
    {
        if (_isReady)
        {
            if (_enemyDetector.EnemyDetected)
            {
                if (_stealLifeCoroutine != null)
                {
                    StopCoroutine(_stealLifeCoroutine);
                }

                _stealLifeCoroutine = StartCoroutine(StealLife(health));

                if (_reloadCoroutine != null)
                {
                    _reloadCoroutine = StartCoroutine(Relodoad());
                }

                _isReady = false;
            }
            else
            {
                if (_stealLifeCoroutine != null)
                {
                    StopCoroutine(_stealLifeCoroutine);
                }
            }
        }
    }

    private IEnumerator Relodoad()
    {
        float timer = 0;

        while (timer < _stealLifePeriod)
        {
            timer += Time.deltaTime;

            if (timer >= _stealLifePeriod)
            {
                _isReady = true;

                yield return null;
            }
        }
    }

    private IEnumerator StealLife(Health health)
    {
        WaitForSecondsRealtime waitForSeconds = new WaitForSecondsRealtime(_stealLifePeriod);

        while (health != null)
        {
            health.TakeDamage(_stealLifeStrength);

            Debug.Log(_stealLifeStrength);

            yield return waitForSeconds;
        }

        _isReady = true;
    }
}
