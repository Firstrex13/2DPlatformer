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
    }

    private void Activate()
    {
        if (_switchOn_OffCoroutine != null)
        {
            StopCoroutine(_switchOn_OffCoroutine);
        }

        _switchOn_OffCoroutine = StartCoroutine(SwitchOn_Off());
    }

    private IEnumerator SwitchOn_Off()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_abilityTime);

        _abilityZone.SetActive(true);

        yield return waitForSeconds;

        _abilityZone.SetActive(false);
    }

    private void VampireAttack(Health health)
    {
        if (_stealLifeCoroutine != null)
        {
            StopCoroutine(_stealLifeCoroutine);
        }

        _stealLifeCoroutine = StartCoroutine(StealLife(health));
    }

    private IEnumerator StealLife(Health health)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_stealLifePeriod);

        while (health != null)
        {
            health.TakeDamage(_stealLifeStrength);

            yield return waitForSeconds;
        }
    }
}
