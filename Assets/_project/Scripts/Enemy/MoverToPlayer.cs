using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoverToPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 _player;

    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void GetPlayerPosition(Vector3 player)
    {
        _player = player;
    }

    private void Move()
    {
        Vector3 direction = (_player - transform.position).normalized;

        direction = new Vector3(direction.x, 0, 0);

        _rigidbody2D.linearVelocity = direction * _speed;
    }
}
