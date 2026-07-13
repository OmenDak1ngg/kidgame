using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SettingsButton : UIButton
{
    [SerializeField] private WindowSettings _windowSettings;

    protected override void OnClick()
    {
        if(_windowSettings.gameObject.activeInHierarchy == false)
            _windowSettings.gameObject.SetActive(true);
        else
            _windowSettings.gameObject.SetActive(false);
    }
}
