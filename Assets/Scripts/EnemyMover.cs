using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform[] _targetPoints;

    [SerializeField] private float _speed;

    private Rigidbody2D _rigidBody2D;

    private float _distanceToTarget = 0.1f;

    private int _pointIndex;

    private void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        foreach (var point in _targetPoints)
        {
            point.parent = null;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (IsTargetReached())
        {
            GetIndex();
        }

        Vector3 direction = (_targetPoints[_pointIndex].position - transform.position).normalized;

        _rigidBody2D.linearVelocity = direction * _speed;
    }

    public bool IsTargetReached()
    {
        return Utilits.IsEnoughClose(transform.position, _targetPoints[_pointIndex].position, _distanceToTarget);
    }

    private int GetIndex()
    {
        return _pointIndex = ++_pointIndex % _targetPoints.Length;
    }
}
