using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleGroup : MonoBehaviour
{
    [SerializeField] private List<UIToggle> _toggles = new List<UIToggle>();

    public event Action<int> ToggleChanged;

    private void OnEnable()
    {
        foreach (var toggle in _toggles)
        {
            if (toggle != null)
            {
                toggle.Changed += OnToggleChanged;
            }
        }
    }

    private void OnDisable()
    {
        foreach (var toggle in _toggles)
        {
            if (toggle != null)
            {
                toggle.Changed -= OnToggleChanged;
            }
        }
    }

    private void OnToggleChanged(bool isOn)
    {
        if (isOn)
        {
            UIToggle sourceToggle = GetCurrentSender(); 

            if (sourceToggle != null)
            {
                DeactivateOthers(sourceToggle);
                ToggleChanged?.Invoke(_toggles.IndexOf(sourceToggle));
            }
        }
    }

    private void DeactivateOthers(UIToggle activeToggle)
    {
        foreach (var toggle in _toggles)
        {
            if (toggle != null && toggle != activeToggle)
            {
                toggle.ChangeValue(false, notify: false);
            }
        }
    }

    private UIToggle GetCurrentSender()
    {
        foreach (var toggle in _toggles)
        {
            if (toggle != null && toggle.GetComponent<Toggle>().isOn)
            {
                return toggle;
            }
        }

        return null;
    }

    public void DeactivateAll()
    {
        foreach (var toggle in _toggles)
        {
            if (toggle != null)
            {
                toggle.ChangeValue(false, notify: false);
            }
        }
    }
}