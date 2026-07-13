using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : UIButton
{
    [SerializeField] private Sprite _pausedSprite;
    [SerializeField] private Sprite _resumedSprite;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    protected override void OnClick()
    {
        if (PauseManager.IsPaused)
        {
            _image.sprite = _resumedSprite;
            PauseManager.Resume();
        }
        else 
        {
            _image.sprite = _pausedSprite;
            PauseManager.Pause();
        }
    }
}
