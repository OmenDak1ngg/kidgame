using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class UIToggle : MonoBehaviour
{
    private Toggle _toggle;

    public event Action<bool> Changed;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
    }

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(OnChanged);
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(OnChanged);
    }

    private void OnChanged(bool value)
    {
        Changed?.Invoke(value);
    }

    public void ChangeValue(bool value, bool notify = true)
    { 
        if(notify)
            _toggle.isOn = value;
        else
            _toggle.SetIsOnWithoutNotify(value);
    }
}
