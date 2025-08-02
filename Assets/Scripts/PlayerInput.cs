using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector2 _inputVector = new Vector2(0, 0);

    private void Update()
    {
        _inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
    }

    public Vector2 GetInput()
    {
        return _inputVector;
    }
}
