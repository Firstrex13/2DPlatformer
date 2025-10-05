using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayer;

    [SerializeField] private float _abilityRadius = 1.5f;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    public Enemy DetectEnemy()
    {
        ContactFilter2D filter = new ContactFilter2D();

        filter.useTriggers = true;

        filter.SetLayerMask(_enemyLayer);

        float minDistance = float.MaxValue;

        Enemy nearestEnemy = null;

        Collider2D[] colliders = new Collider2D[10];

        int count =  Physics2D.OverlapCircle(_transform.position, _abilityRadius, filter, colliders);

        if (count > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                float distanceSquared = Vector3.SqrMagnitude(_transform.position - colliders[i].transform.position);

                if (distanceSquared < minDistance)
                {
                    if (colliders[i].TryGetComponent<Enemy>(out var currentEnemy))
                    {
                      
                        minDistance = distanceSquared;

                        nearestEnemy = currentEnemy;

                        if (nearestEnemy != null)
                        {
                            return nearestEnemy;
                        }
                    }
                }
            }
        }

        return null;
    }
}
