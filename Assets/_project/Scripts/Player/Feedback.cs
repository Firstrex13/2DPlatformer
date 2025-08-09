using UnityEngine;

public class Feedback : MonoBehaviour
{
    [SerializeField] private Health _health;

    [SerializeField] private PlayerMovement _playerMovement;

    private void OnEnable()
    {
        _health.Hit += InteruptMovement;
    }

    private void OnDisable()
    {
        _health.Hit -= InteruptMovement;
    }

    private void InteruptMovement()
    {
        StartCoroutine(_playerMovement.InterruptMove());
    }
}
