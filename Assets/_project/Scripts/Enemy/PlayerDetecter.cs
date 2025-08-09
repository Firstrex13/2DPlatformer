using UnityEngine;

public class PlayerDetecter : MonoBehaviour
{
    [SerializeField] private MoverPointByPoint _pointByPointMover;
    [SerializeField] private MoverToPlayer _moverToPlayer;
    [SerializeField] private EnemyAnimations _enemyAnimations;

    private void Start()
    {
        _moverToPlayer.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _))
        {
            _enemyAnimations.PlayRunnig();
            _pointByPointMover.enabled = false;
            _moverToPlayer.enabled = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _moverToPlayer.GetPlayerPosition(player);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _))
        {
            _pointByPointMover.enabled = true;
            _moverToPlayer.enabled = false;
            _enemyAnimations.PlayIdle();
        }
    }
}




