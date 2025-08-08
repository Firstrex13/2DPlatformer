using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimations : MonoBehaviour
{
    private readonly int Running = Animator.StringToHash(nameof(Running));
    private readonly int Jumping = Animator.StringToHash(nameof(Jumping));
    private readonly int Falling = Animator.StringToHash(nameof(Falling));
    private readonly int Hit = Animator.StringToHash(nameof(Hit));

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

    public void PlayHit()
    {
        _animator.SetTrigger(Hit);
    }
}
