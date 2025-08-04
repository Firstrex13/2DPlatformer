using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoverPointByPoint : MonoBehaviour
{
    [SerializeField] private Transform[] _targetPoints;

    [SerializeField] private float _speed;

    private Rigidbody2D _rigidBody2D;

    private float _distanceToTarget = 0.1f;

    private int _pointIndex;

    private Vector3 _enemyXPosition;
    private Vector3 _targetXPosition;

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
        _enemyXPosition = new Vector3(transform.position.x, 0, 0);
        _targetXPosition = new Vector3(_targetPoints[_pointIndex].position.x, 0, 0);

        if (IsTargetReached())
        {
            GetIndex();
        }

        Vector3 direction = (_targetPoints[_pointIndex].position - transform.position).normalized;
        direction = new Vector3(direction.x, 0, 0);

        _rigidBody2D.linearVelocity = direction * _speed;
    }

    public bool IsTargetReached()
    {
        return Utilits.IsEnoughClose(_enemyXPosition, _targetXPosition, _distanceToTarget);
    }

    private int GetIndex()
    {
        return _pointIndex = ++_pointIndex % _targetPoints.Length;
    }
}
