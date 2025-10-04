using System.Collections;
using UnityEngine;

public class VampireAbility : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;

    [SerializeField] private PlayerInput _input;

    [SerializeField] private GameObject _abilityZone;

    [SerializeField] private float _stealLifeStrength;

    [SerializeField] private EnemyDetector _enemyDetector;

    private float _abilityTime = 6f;

    private float _cooldown = 4f;

    private Coroutine _switchOn_OffCoroutine;

    private bool _isActivated;

    private bool _isOnCooldown;

    public bool IsActivated => _isActivated;
    public float AbilityTime => _abilityTime;
    public float Cooldown => _cooldown;

    public void Initialize(PlayerInput input)
    {
        _input = input;
    }

    private void OnEnable()
    {
        _input.AbilityButtonPressed += ActivateOnButtonClick;
    }

    private void OnDisable()
    {
        _input.AbilityButtonPressed -= ActivateOnButtonClick;
    }

    private void Start()
    {
        _abilityZone.SetActive(false);
        _isActivated = false;
    }

    private void ActivateOnButtonClick()
    {
        if (_isActivated || _isOnCooldown)
        {
            return;
        }

        if (_switchOn_OffCoroutine != null)
        {
            StopCoroutine(_switchOn_OffCoroutine);
        }

        _switchOn_OffCoroutine = StartCoroutine(VampireAttack());
    }

    private IEnumerator VampireAttack()
    {
        _abilityZone.SetActive(true);

        _isActivated = true;

        yield return StealLife();

        _isActivated = false;

        _abilityZone.SetActive(false);

        _isOnCooldown = true;

        yield return new WaitForSeconds(_cooldown);

        _isOnCooldown = false;
    }

    private IEnumerator StealLife()
    {

        float elapsedTime = 0;

        while (elapsedTime < _abilityTime)
        {
            var enemy = _enemyDetector.GetClosestEnemyHealth();

            if (enemy != null)
            {
                enemy.TakeDamage(_stealLifeStrength * Time.deltaTime);

                _playerHealth.ApplyHeal(_stealLifeStrength * Time.deltaTime);
            }

            elapsedTime += Time.deltaTime;

            yield return null;
        }
    }
}
