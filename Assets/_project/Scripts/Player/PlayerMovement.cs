using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private PlayerAnimations _playerAnimations;

    [SerializeField] private int _speed;
    [SerializeField] private int _jumpForce;

    [SerializeField] private bool _canMove = true;

    public Rigidbody2D RigidBody2D { get; private set; }

    private void Awake()
    {
        RigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _input.JumpButtonPressed += Jump;
    }

    private void OnDisable()
    {
        _input.JumpButtonPressed -= Jump;
    }

    private void Update()
    {
        if (RigidBody2D.linearVelocityY > 0)
        {
            _playerAnimations.PlayJump();
        }
        else if (RigidBody2D.linearVelocityY < 0)
        {
            _playerAnimations.PlayFall();
        }

        if (_groundDetector.IsGrounded)
        {
            _playerAnimations.StopFallingAnimation();
        }
    }

    private void FixedUpdate()
    {
        if (_canMove)
        {
            Move();
        }
    }

    public void Initialize(PlayerInput input)
    {
        _input = input;
    }

    public IEnumerator InterruptMove()
    {
        float delay = 0.3f;

        WaitForSeconds waitForSeconds = new WaitForSeconds(delay);

        _canMove = false;

        yield return waitForSeconds;

        _canMove = true;
    }

    private void Move()
    {
        Vector2 moveDirection = new Vector2(_input.InputVector.x * _speed * Time.fixedDeltaTime, RigidBody2D.linearVelocity.y);

        RigidBody2D.linearVelocity = moveDirection;

        if (Mathf.Abs(RigidBody2D.linearVelocityX) > 0)
        {
            _playerAnimations.PlayRun();
        }
        else
        {
            _playerAnimations.PlayIdle();
        }
    }

    private void Jump()
    {
        if (_input.SpacePressed && _groundDetector.IsGrounded && _canMove)
        {
            RigidBody2D.AddForceY(_jumpForce);
        }
    }
}
