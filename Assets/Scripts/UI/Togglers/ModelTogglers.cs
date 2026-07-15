using System;
using UnityEngine;

public class ModelTogglers : MonoBehaviour
{
    [SerializeField] private UIToggle _firstToggle;
    [SerializeField] private UIToggle _secongToggle;

    public event Action<bool> FirstToggleChanged;

    private void OnEnable()
    {
        _firstToggle.Changed += OnFirstModelChanged;
        _secongToggle.Changed += OnSecondModelChoosed;
    }

    private void OnDisable()
    {
        _firstToggle.Changed -= OnFirstModelChanged;
        _secongToggle.Changed -= OnSecondModelChoosed;
    }
    private void OnFirstModelChanged(bool value)
    {
        _secongToggle.ChangeValue(!value, false);

        FirstToggleChanged?.Invoke(value);
    }

    private void OnSecondModelChoosed(bool value)
    {
        _firstToggle.ChangeValue(!value, false);

        FirstToggleChanged?.Invoke(!value);
    }

    public void ChangeToggleValue(bool value, int numberOfToggle, bool notify = false)
    {
        switch (numberOfToggle)
        {
            case 1:
                _firstToggle.ChangeValue(value, notify);
                break;

            case 2:
                _secongToggle.ChangeValue(value, notify);
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
