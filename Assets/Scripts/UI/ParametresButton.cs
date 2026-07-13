using UnityEngine;
using UnityEngine.UI;

public class ParametresButton: UIButton
{
    [SerializeField] private ParametresWindow _windowSettings;

    protected override void OnClick()
    {
        if (_windowSettings.gameObject.activeInHierarchy == false)
            _windowSettings.gameObject.SetActive(true);
        else
            _windowSettings.gameObject.SetActive(false);
    }
}
