using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class UISlider : MonoBehaviour
{
    private Slider _slider;

    public event Action<float> ValueChanged;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }
    
    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(OnValueChanged);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(OnValueChanged);
    }

    private void OnValueChanged(float value)
    {
        ValueChanged?.Invoke(value);
    }

    public void ChangeValue(float value)
    {
        _slider.value = value;
    }
}
