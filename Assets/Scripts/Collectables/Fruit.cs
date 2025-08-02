using System;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public Action PickedUp;

    public void Collect()
    {
        PickedUp?.Invoke();
        Destroy(gameObject);
    }
}
