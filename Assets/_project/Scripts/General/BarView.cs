using UnityEngine;
using UnityEngine.UI;

public class BarView : MonoBehaviour
{
    [SerializeField] private VampireAbility _vampireAbility;

    [SerializeField] private Slider _slider;

    private void Start()
    {
        _slider.value = 1;
    }

    private void Update()
    {
        if (_vampireAbility.IsActivated)
        {
            Decrease();
        }
        else
        {
            Reload();
        }
    }

    private void Decrease()
    {
        {
            _slider.value = Mathf.MoveTowards(_slider.value, 0, Time.deltaTime / _vampireAbility.AbilityTime);
        }
    }

    private void Reload()
    {
        _slider.value = Mathf.MoveTowards(_slider.value, 1, Time.deltaTime / _vampireAbility.Cooldown);
    }
}
