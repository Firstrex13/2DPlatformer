using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    private const string Idle = nameof(Idle);
    private const string Running = nameof(Running);
    private const string Hit = nameof(Hit);

    [SerializeField] private Animator _animator;

    public void PlayIdle()
    {
        _animator.SetBool(Running, false);
        _animator.SetBool(Idle, true);
    }

    public void PlayRunnig()
    {
        _animator.SetBool(Idle, false);
        _animator.SetBool(Running, true);
    }

    public void PlayHit()
    {
        _animator.SetTrigger(Hit);
    }
}
