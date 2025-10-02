using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    private Vector2 _inputVector = new Vector2(0, 0);

    public Vector2 InputVector => _inputVector;

    public bool SpacePressed { get; private set; }
    public bool FButtonPressed { get; private set; }

    public Action JumpButtonPressed;

    public Action AbilityButtonPressed;

    private void Update()
    {
        _inputVector = new Vector2(Input.GetAxisRaw(Horizontal), 0);

        if (SpacePressed = Input.GetKeyDown(KeyCode.Space))
        {
            JumpButtonPressed?.Invoke();
        }

        if (FButtonPressed = Input.GetKeyDown(KeyCode.F))
        {
            AbilityButtonPressed?.Invoke();
        }
    }
}
