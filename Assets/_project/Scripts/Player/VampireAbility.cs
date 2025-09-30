using System.Collections;
using UnityEngine;

public class VampireAbility : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;

    [SerializeField] private PlayerInput _input;

    [SerializeField] private EnemyCheck _enemyCheck;

    [SerializeField] private GameObject _object;

    [SerializeField] private int _stealLifeStrength;

    private float _abilityTime = 6f;

    public void Initialize(PlayerInput input)
    {
        _input = input;
    }

    private void OnEnable()
    {
        _input.AbilityButtonPressed += Activate;

        _enemyCheck.Detected += StealLife;
    }

    private void OnDisable()
    {
        _input.AbilityButtonPressed -= Activate;

        _enemyCheck.Detected -= StealLife;
    }

    private void Start()
    {
        _object.SetActive(false);
    }

    private void Activate()
    {
        _object.SetActive(true);

        StartCoroutine(DeActivate());
    }

    private IEnumerator DeActivate()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_abilityTime);

        yield return waitForSeconds;

        _object.SetActive(false);
    }

    private void StealLife(Health health)
    {
        _playerHealth.HealSmooth();

       StartCoroutine(health.DamageSmooth(_stealLifeStrength));
    }
}
