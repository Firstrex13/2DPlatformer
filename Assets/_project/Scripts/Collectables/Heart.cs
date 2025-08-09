using UnityEngine;

public class Heart : MonoBehaviour
{
    public int HealAmount {  get; private set; }

    private void Start()
    {
        HealAmount = 1;
    }

    public void Heal(Health health)
    {
        health.ApplyHeal(HealAmount);
    }

    public void DestroyHeart()
    {
        Destroy(gameObject);
    }
}
