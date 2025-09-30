using Unity.Cinemachine;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private CinemachineCamera _camera;
    [SerializeField] private Transform _player;

    public void Initialize(Transform player)
    {
        _player = player;
    }

    private void Start()
    {
        _camera.Follow = _player.transform;
    }
}
