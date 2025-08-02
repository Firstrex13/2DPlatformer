using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private PlayerAnimations _playerAnimations;

    [SerializeField] private int _speed;
    [SerializeField] private int _jumpForce;

    public Rigidbody2D RigidBody2D { get; private set; }

    private void Awake()
    {
        RigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_input.SpacePressed && _groundDetector.IsGrounded)
        {
            Jump();
        }

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
        Move();
    }

    private void Move()
    {
        Vector2 moveDirection = new Vector2(_input.GetInput().x * _speed * Time.fixedDeltaTime, RigidBody2D.linearVelocity.y);

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
        RigidBody2D.AddForceY(_jumpForce);
    }
}
