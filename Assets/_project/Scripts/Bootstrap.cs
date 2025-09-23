using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private FruitCountView _fruitCountView;

    [SerializeField] private PlayerInput _input;

    [SerializeField] private Camera _camera;

    [SerializeField] private PlayerSpawner _playerSpawner;

    private void Awake()
    {
        _playerSpawner.Initialize(_fruitCountView, _input, _camera);
    }
}
