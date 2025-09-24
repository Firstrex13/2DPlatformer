using UnityEngine;

public class Recoiler : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;

    [SerializeField] private int _recoilStretgth;

    private Vector2 _direction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<IDamageable>(out _))
        {
            _direction = _rigidbody2D.linearVelocity;

            _rigidbody2D.AddForce(-_direction * _recoilStretgth);
        }
    }

}
