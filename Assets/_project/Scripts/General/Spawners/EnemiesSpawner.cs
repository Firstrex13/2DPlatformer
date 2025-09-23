using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;

    [SerializeField] private Transform[] _enemySpawnPositions;

    private void Awake()
    {
        for (int i = 0; i < _enemySpawnPositions.Length; i++)
        {
            var enemy = Instantiate(_enemyPrefab, _enemySpawnPositions[i]);
        }
    }
}
