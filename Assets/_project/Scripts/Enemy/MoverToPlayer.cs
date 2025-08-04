using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class MoverToPlayer : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private Rigidbody2D _rigidbody2D;

    [SerializeField] private float _speed;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D> ();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
       
        Vector3 direction = (_player.position - transform.position).normalized;

        direction = new Vector3 (direction.x, 0, 0);

        _rigidbody2D.linearVelocity = direction * _speed;
    }
}
