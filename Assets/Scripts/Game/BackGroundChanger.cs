
using UnityEngine;
using UnityEngine.UI;

public class BackGroundChanger : MonoBehaviour
{
    [SerializeField] private Sprite _mainSprite;
    [SerializeField] private Sprite _alternativeSprite;

    [SerializeField] private Image _image;
    [SerializeField] private UIToggle _toggle;

    private void OnEnable()
    {
        _toggle.Changed += ChangeBackground;
    }

    private void OnDisable()
    {
        _toggle.Changed -= ChangeBackground;
    }

    private void ChangeBackground(bool isChoosedAlternativeBackground)
    {
        Sprite currentSprite = isChoosedAlternativeBackground ? _alternativeSprite : _mainSprite;

        _image.sprite = currentSprite;
    }
}
