using System;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGroup : MonoBehaviour
{
    [SerializeField] private List<UIToggle> _toggles = new List<UIToggle>();

    public event Action<int> ToggleChanged;

    private readonly Dictionary<UIToggle, Action<bool>> _cachedActions = new Dictionary<UIToggle, Action<bool>>();

    private void OnEnable()
    {
        foreach (var toggle in _toggles)
        {
            if (toggle != null)
            {
                UIToggle currentToggle = toggle;
                Action<bool> action = (isOn) => OnToggleChanged(currentToggle, isOn);
                _cachedActions[currentToggle] = action;
                currentToggle.Changed += action;
            }
        }
    }

    private void OnDisable()
    {
        foreach (var pair in _cachedActions)
        {
            UIToggle toggle = pair.Key;
            Action<bool> action = pair.Value;

            if (toggle != null)
            {
                toggle.Changed -= action;
            }
        }

        _cachedActions.Clear();
    }

    private void OnToggleChanged(UIToggle sourceToggle, bool isOn)
    {
        if (isOn && sourceToggle != null)
        {
            DeactivateOthers(sourceToggle);
            ToggleChanged?.Invoke(_toggles.IndexOf(sourceToggle));
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
