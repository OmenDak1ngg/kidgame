using System;
using UnityEngine;
using UnityEngine.UI;

public class ModelChanger : MonoBehaviour
{
    [SerializeField] private Sprite _firstSprite;
    [SerializeField] private Sprite _secondSprite;

    [SerializeField] private Image _kidImage;

    [SerializeField] private ModelTogglers _modelTogglers;

    public bool IsFirstModelChoosed { get; private set; }
    
    public event Action ModelChanged;

    private void OnEnable()
    {
        _modelTogglers.FirstToggleChanged += ChangeModel;
    }

    private void OnDisable()
    {
        _modelTogglers.FirstToggleChanged -= ChangeModel;  
    }

    private void ChangeModel(bool isFirstModelChoosed)
    {
        Sprite currentSprite = isFirstModelChoosed ? _firstSprite : _secondSprite;

        _kidImage.sprite = currentSprite;

        IsFirstModelChoosed = isFirstModelChoosed;
        ModelChanged?.Invoke();

        SaveSystem.SaveCharacterNumber(isFirstModelChoosed ? 1 : 2);
    }

    public void ChangeModel(int number)
    {
        Sprite currentSprite;

        switch (number)
        {
            case 1:
                currentSprite = _firstSprite;
                break;

            case 2:
                currentSprite = _secondSprite;
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }

        _kidImage.sprite = currentSprite;
        IsFirstModelChoosed = number == 1 ? true : false;
        ModelChanged?.Invoke();

        _modelTogglers.ChangeToggleValue(true, number, false);
        _modelTogglers.ChangeToggleValue(false, number == 1 ? 2 : 1, false);
    }
}
