using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Player _playerPrefab;

    [SerializeField] private Transform _playerSpawnPosition;

    private FruitCountView _fruitCountView;

    private PlayerInput _input;

    private CameraMover _camera;

    public void Initialize(FruitCountView fruitCountView, PlayerInput input, CameraMover camera)
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

        if (player.TryGetComponent <VampireAbility>(out VampireAbility vampireAbility))
        {
            vampireAbility.Initialize(_input);
        }

        player.gameObject.SetActive(true);

        _camera.Initialize(player.transform);
    }
}
