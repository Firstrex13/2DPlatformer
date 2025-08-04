using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    private int _contactCounts = 0;

    public bool IsGrounded => _contactCounts != 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _))
        {
            _contactCounts++;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _))
        {
            _contactCounts--;

            if (_contactCounts < 0)
            {
                _contactCounts = 0;
            }
        }
    }
}
