using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]

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
        Rotate();
    }

    private void Move()
    {
        if (IsTargetReached())
        {
            GetIndex();
        }

        _rigidBody2D.position = Vector2.MoveTowards(transform.position, _targetPoints[_pointIndex].position, Time.fixedDeltaTime * _speed);
    }

    private float GetSqrDistance(Vector2 start, Vector2 end)
    {
        return (end - start).sqrMagnitude;
    }

    private bool IsEnoughClose(Vector2 start, Vector2 end, float distance)
    {
        return GetSqrDistance(start, end) <= distance * distance;
    }

    public bool IsTargetReached()
    {
        return IsEnoughClose(transform.position, _targetPoints[_pointIndex].position, _distanceToTarget);
    }

    private int GetIndex()
    {
        return _pointIndex = ++_pointIndex % _targetPoints.Length;
    }

    private void Rotate()
    {
        if (_pointIndex == 1)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (_pointIndex == 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }
}
