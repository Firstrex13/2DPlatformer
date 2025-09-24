using UnityEngine;

public class Fruit : MonoBehaviour, ICollectable
{
    public void Collect()
    {
        Destroy(gameObject);
    }
}
