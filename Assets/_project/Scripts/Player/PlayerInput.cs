using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    private Vector2 _inputVector = new Vector2(0, 0);

    public Vector2 InputVector => _inputVector;

    public bool SpacePressed { get; private set; }

    public Action JumpButtonPressed;

    private void Update()
    {
        _inputVector = new Vector2(Input.GetAxisRaw(Horizontal), 0);

        if(SpacePressed = Input.GetKeyDown(KeyCode.Space))
        {
            JumpButtonPressed?.Invoke();
        }
    }
}
