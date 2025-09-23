using UnityEngine;

public class HealthViewBasic : MonoBehaviour
{
    [SerializeField] protected Health Health;

    private void Awake()
    {
        Health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        Health.Hit += UpdateValue;
        Health.Healed += UpdateValue;
    }

    private void OnDisable()
    {
        Health.Hit -= UpdateValue;
        Health.Healed -= UpdateValue;
    }

    public virtual void UpdateValue() { }
}
