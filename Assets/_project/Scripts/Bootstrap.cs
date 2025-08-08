using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private FruitCountView _fruitCountView;

    [SerializeField] private PlayerInput _input;

    [SerializeField] private Camera _camera;

    [SerializeField] private Spawner _spawner;

    private void Awake()
    {
        _spawner.Initialize(_fruitCountView, _input, _camera);
    }
}
