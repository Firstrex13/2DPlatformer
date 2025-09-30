using System.Collections;
using UnityEngine;

public class VampireAbility : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;

    [SerializeField] private PlayerInput _input;

    [SerializeField] private EnemyCheck _enemyCheck;

    [SerializeField] private GameObject _abilityZone;

    [SerializeField] private int _stealLifeStrength;

    [SerializeField] private float _stealLifePeriod;

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
        _abilityZone.SetActive(false);
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

    private void StealLife(Health health)
    {
        StartCoroutine(Steal(health));
    }

    private IEnumerator Steal(Health health)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_stealLifePeriod);

        while (enabled)
        {
            yield return waitForSeconds;

            Debug.Log("Урон.");
        }
    }
}
