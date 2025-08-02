using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerInput _input;
    [SerializeField] GroundDetector _groundDetector;

    [SerializeField] private int _speed;
    [SerializeField] private int _jumpForce;

    public Rigidbody2D RigidBody2D { get; private set; }

    private void Awake()
    {
        RigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _groundDetector.IsGrounded)
        {
            Jump();
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
    } 

    private void Jump()
    {
        RigidBody2D.AddForceY(_jumpForce);
    }
}
