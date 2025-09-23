using UnityEngine;

public class BarFollowObject : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void Start()
    {
        gameObject.transform.parent = null;
    }

    private void Update()
    {
        if (_target != null)
        {
            transform.position = _target.position;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
