using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _heartPrefab;

    [SerializeField] private Transform _playerSpawnPosition;
    [SerializeField] private Transform[] _enemySpawnPositions;
    [SerializeField] private Transform[] _heartSpawnPositions;

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

        Counter counter = player.GetComponent<Counter>();

        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

        playerMovement.Initialize(_input);

        for (int i = 0; i < _enemySpawnPositions.Length; i++)
        {
            var enemy = Instantiate(_enemyPrefab, _enemySpawnPositions[i]);
        }

        _fruitCountView.Initialize(counter);

        for (int i = 0; i < _heartSpawnPositions.Length; i++)
        {
            Instantiate(_heartPrefab, _heartSpawnPositions[i]);
        }

        _camera.Initialize(player.transform);
    }
}
