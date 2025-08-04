using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private int _pushStrengthX = 10;
    [SerializeField] private int _pushStrengthY = 10;

    [SerializeField] private Rigidbody2D _rigidbody2D;

    private int _damageValue = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health player))
        {
            Rigidbody2D rigidbody2D = player.GetComponent<Rigidbody2D>();
            PlayerMovement movement = player.GetComponent<PlayerMovement>();

            player.TakeDamage(_damageValue);
            StartCoroutine(movement.InterruptMove());
            Push(rigidbody2D);
        }
    }

    private void Push(Rigidbody2D rigidbody2D)
    {
        rigidbody2D.AddForce(new Vector2(_rigidbody2D.linearVelocity.x * _pushStrengthX, _pushStrengthY), ForceMode2D.Impulse);
    }
}
