using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    private readonly int Idle = Animator.StringToHash(nameof(Idle));
    private readonly int Running = Animator.StringToHash(nameof(Running));
    private readonly int Hit = Animator.StringToHash(nameof(Hit));

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
