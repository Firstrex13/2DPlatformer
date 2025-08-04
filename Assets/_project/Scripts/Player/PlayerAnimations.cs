using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimations : MonoBehaviour
{
    private const string Running = nameof(Running);
    private const string Jumping = nameof(Jumping);
    private const string Falling = nameof(Falling);

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayRun()
    {
        _animator.SetBool(Running, true);
    }

    public void PlayIdle()
    {
        _animator.SetBool(Running, false);
    }

    public void PlayJump()
    {
        _animator.SetBool(Jumping, true);
    }

    public void PlayFall()
    {
        _animator.SetBool(Jumping, false);
        _animator.SetBool(Falling, true);
    }

    public void StopFallingAnimation()
    {
        _animator.SetBool(Falling, false);
    }
}
