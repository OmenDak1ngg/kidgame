using System;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Button))]
public class UIButton : MonoBehaviour
{
    private Button _button;

    public event Action Clicked;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        if (_button == null)
            _button = GetComponent<Button>();

        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    protected virtual void OnClick()
    {
        Clicked?.Invoke();
    }
}

