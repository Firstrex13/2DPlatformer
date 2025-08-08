using UnityEngine;

public class Feedback : MonoBehaviour
{
    [SerializeField] private Health _health;

    [SerializeField] private PlayerMovement _playerMovement;

    private void OnEnable()
    {
        _health.ChangedDown += InteruptMovement;
    }

    private void OnDisable()
    {
        _health.ChangedDown -= InteruptMovement;
    }

    private void InteruptMovement()
    {
        StartCoroutine(_playerMovement.InterruptMove());
    }
}
