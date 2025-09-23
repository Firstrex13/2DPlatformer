using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;

    private void Update()
    {
        Rotate();
    }
    private void Rotate()
    {
        if (_rigidbody2D.linearVelocity.x > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (_rigidbody2D.linearVelocity.x < 0)
        {
            transform.localRotation = Quaternion.Euler(0, -180, 0);
        }
    }
}
