using UnityEngine;

public class ItemsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _heartPrefab;

    [SerializeField] private Transform[] _heartSpawnPositions;

    private void Awake()
    {
        for (int i = 0; i < _heartSpawnPositions.Length; i++)
        {
            Instantiate(_heartPrefab, _heartSpawnPositions[i]);
        }
    }
}

