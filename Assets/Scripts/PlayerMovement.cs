using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private int _jumpForce;

    private float _horizontalInput;

    public Rigidbody2D _rigidBody2D { get; private set; }
    public bool _isGrounded { get; private set; }

    private void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        Vector2 moveDirection = new Vector2(_horizontalInput * _speed * Time.fixedDeltaTime, _rigidBody2D.linearVelocity.y);

        _rigidBody2D.linearVelocity = moveDirection;
    }

    private void Rotate()
    {
        if (_rigidBody2D.linearVelocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (_rigidBody2D.linearVelocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void Jump()
    {
        _rigidBody2D.AddForceY(_jumpForce);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        _isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGrounded = false;
    }
}
