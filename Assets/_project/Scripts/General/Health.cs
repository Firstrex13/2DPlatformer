using UnityEngine;

[SelectionBase]
public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if(damage < 0)
        {
            damage = 0;
        }

        _currentHealth -= damage;

        if(_currentHealth <= 0)
        {
            Die();
        }
    }

    public void ApplyHeal(int healAmount)
    {
        if (healAmount < 0)
        {
            healAmount = 0;
        }

        _currentHealth += healAmount;

        if(_currentHealth >= _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}


