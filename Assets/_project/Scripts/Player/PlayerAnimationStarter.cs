using UnityEngine;

public class PlayerAnimationStarter : MonoBehaviour
{
    [SerializeField] private PlayerAnimations _playerAnimations;
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.Hit += _playerAnimations.PlayHit;
    }

    private void OnDisable()
    {
        _health.Hit -= _playerAnimations.PlayHit;
    }
}
