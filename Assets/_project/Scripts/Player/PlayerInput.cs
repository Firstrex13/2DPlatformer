using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    private Vector2 _inputVector = new Vector2(0, 0);
    public bool SpacePressed { get; private set; }

    private void Update()
    {
        _inputVector = new Vector2(Input.GetAxisRaw(Horizontal), 0);

        SpacePressed = Input.GetKeyDown(KeyCode.Space);
    }

    public Vector2 GetInput()
    {
        return _inputVector;
    }
}
