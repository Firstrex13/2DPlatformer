using UnityEngine;

public class PlayerAnimationStarter : MonoBehaviour
{
    [SerializeField] private PlayerAnimations _playerAnimations;
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.ChangedDown += _playerAnimations.PlayHit;
    }

    private void OnDisable()
    {
        _health.ChangedDown -= _playerAnimations.PlayHit;
    }
}
