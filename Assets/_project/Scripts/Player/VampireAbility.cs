using System.Collections;
using UnityEngine;

public class VampireAbility : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;

    [SerializeField] private PlayerInput _input;

    [SerializeField] private GameObject _abilityZone;

    [SerializeField] private float _stealLifeStrength;

    [SerializeField] private EnemyDetector _enemyDetector;

    private Coroutine _attackCoroutine;

    public bool IsActivated { get; private set; } 

    public bool IsOnCooldown { get; private set; }

    public float AbilityTime { get; private set; }
    public float Cooldown {  get; private set; }

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
        IsActivated = false;
        AbilityTime = 6f;
        Cooldown = 4f;
        IsOnCooldown = false;
    }

    private void ActivateOnButtonClick()
    {
        if (IsActivated || IsOnCooldown)
        {
            return;
        }

        if (_attackCoroutine != null)
        {
            StopCoroutine(_attackCoroutine);
        }

        _attackCoroutine = StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        _abilityZone.SetActive(true);

        IsActivated = true;

        yield return StealLife();

        IsActivated = false;

        _abilityZone.SetActive(false);

        IsOnCooldown = true;

        yield return new WaitForSeconds(Cooldown);

        IsOnCooldown = false;
    }

    private IEnumerator StealLife()
    {
        float elapsedTime = 0;

        while (elapsedTime < AbilityTime)
        {
            var enemy = _enemyDetector.DetectEnemy();

            if (enemy != null)
            {
                if(enemy.TryGetComponent<Health>(out Health health))
                {
                    health.TakeDamage(_stealLifeStrength * Time.deltaTime);

                    _playerHealth.ApplyHeal(_stealLifeStrength * Time.deltaTime);
                }           
            }

            elapsedTime += Time.deltaTime;

            yield return null;
        }
    }
}
