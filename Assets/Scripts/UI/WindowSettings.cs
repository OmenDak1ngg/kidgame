using UnityEngine;

public class WindowSettings : UIWindow
{
    [SerializeField] private MainAudio _mainAudio;
    [SerializeField] private UISlider _slider;

    private void OnEnable()
    {
        _slider.ChangeValue(_mainAudio.Volume);    
    }
}
