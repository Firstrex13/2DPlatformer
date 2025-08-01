using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Fruit>(out Fruit fruit))
        {
            fruit.Collect();
        }
    }
}
