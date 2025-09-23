using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class HealthViewBasic : MonoBehaviour
{
    [SerializeField] protected Health Health;

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

    private void Start()
    {
        Health = GetComponent<Health>();
    }

    public virtual void UpdateValue() { }
}
