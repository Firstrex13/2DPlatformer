using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.Died += DestroyObject;
    }

    private void OnDisable()
    {
        _health.Died -= DestroyObject;
    }

    private void DestroyObject(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}
