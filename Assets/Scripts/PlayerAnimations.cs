using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Mathf.Abs(_playerMovement._rigidBody2D.linearVelocityX) > 0)
        {
            PlayRun();
        }
        else
        {
            PlayIdle();
        }

        if(_playerMovement._rigidBody2D.linearVelocityY > 0)
        {
            PlayJump();
        }
        else if(_playerMovement._rigidBody2D.linearVelocityY < 0)
        {
            PlayFall();
        }

        if (_playerMovement._isGrounded)
        {
            _animator.SetBool("Falling", false);
        }
    }

    private void PlayRun()
    {
        _animator.SetBool("Running", true);
    }

    private void PlayIdle()
    {
        _animator.SetBool("Running", false);
    }

    private void PlayJump()
    {
        _animator.SetBool("Jumping", true);
    }

    private void PlayFall()
    {
        _animator.SetBool("Jumping", false);
        _animator.SetBool("Falling", true);
    }
}
