using System;
using UnityEngine;
public class ModelTogglers : MonoBehaviour
{
    [SerializeField] private UIToggle _maleToggle;
    [SerializeField] private UIToggle _femaleToggle;

    public event Action<bool> MaleModelChoosed;

    private void OnEnable()
    {
        _maleToggle.Changed += OnMaleChanged;
        _femaleToggle.Changed += OnFemaleChanged;
    }

    private void OnDisable()
    {
        _maleToggle.Changed -= OnMaleChanged;
        _femaleToggle.Changed -= OnFemaleChanged;
    }
    private void OnMaleChanged(bool value)
    {
        _femaleToggle.ChangeValue(!value, false);

        MaleModelChoosed?.Invoke(value);
    }

    private void OnFemaleChanged(bool value)
    {
        _maleToggle.ChangeValue(!value, false);

        MaleModelChoosed?.Invoke(!value);
    }
}
