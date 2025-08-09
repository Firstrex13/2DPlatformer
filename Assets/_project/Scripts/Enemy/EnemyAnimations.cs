using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    private readonly int _idle = Animator.StringToHash(nameof(_idle));
    private readonly int _running = Animator.StringToHash(nameof(_running));
    private readonly int _hit = Animator.StringToHash(nameof(_hit));

    [SerializeField] private Animator _animator;

    public void PlayIdle()
    {
        _animator.SetBool(_running, false);
        _animator.SetBool(_idle, true);
    }

    public void PlayRunnig()
    {
        _animator.SetBool(_idle, false);
        _animator.SetBool(_running, true);
    }

    public void PlayHit()
    {
        _animator.SetTrigger(_hit);
    }
}
