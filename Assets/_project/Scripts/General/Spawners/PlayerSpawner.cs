using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;

    [SerializeField] private Transform _playerSpawnPosition;

    private FruitCountView _fruitCountView;

    private PlayerInput _input;

    private Camera _camera;

    public void Initialize(FruitCountView fruitCountView, PlayerInput input, Camera camera)
    {
        _fruitCountView = fruitCountView;
        _input = input;
        _camera = camera;
    }

    private void Awake()
    {
        var player = Instantiate(_playerPrefab, _playerSpawnPosition);

        if (player.TryGetComponent<Counter>(out Counter counter))
        {
            _fruitCountView.Initialize(counter);
        }

        if (player.TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement))
        {
            playerMovement.Initialize(_input);
        }

        _camera.Initialize(player.transform);
    }
}
