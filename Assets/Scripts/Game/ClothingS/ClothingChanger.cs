using System;
using UnityEngine;
using UnityEngine.UI;

public class ClothingChanger : MonoBehaviour
{
    [SerializeField] private CharacterAppearance _firstCharacterAppearance;
    [SerializeField] private CharacterAppearance _secondCharacterAppearance;

    [SerializeField] private Image[] _clothingImages;

    [SerializeField] private ModelTogglers _modelTogglers;
    [SerializeField] private ModelChanger _modelChanger;

    private bool _isEnableDefaulReser = true;

    private void OnEnable()
    {
        _modelChanger.ModelChanged += OnModelChanged;
        _modelTogglers.FirstToggleChanged += ChangeSpriteSet;
    }

    private void OnDisable()
    {
        _modelChanger.ModelChanged -= OnModelChanged;
        _modelTogglers.FirstToggleChanged -= ChangeSpriteSet;
    }
    
    private void ChangeSpriteSet(bool isFirstAppearanceChoosed)
    {
        CharacterAppearance currentAppearance = _modelChanger.IsFirstModelChoosed ?
            _firstCharacterAppearance : _secondCharacterAppearance;

        int currentSpriteSetNumber = isFirstAppearanceChoosed ? 1 : 2;

        Sprite[] currentSpriteSet = currentAppearance.GetSpiteSet(currentSpriteSetNumber);

        for(int i = 0;i < currentSpriteSet.Length; i++)
        {
            _clothingImages[i].sprite = currentSpriteSet[i];
        }

        SaveSystem.SaveClothingNumber(currentSpriteSetNumber);
        SaveSystem.SaveAppearanceNumber(_modelChanger.IsFirstModelChoosed ? 1 : 2);
    }

    public void ChangeSpriteSet(int numberOfSpriteSet, int numberOfCharacterAppearance)
    {
        CharacterAppearance currentCharacterAppearance;

        switch (numberOfCharacterAppearance)
        {
            case 1:
                currentCharacterAppearance = _firstCharacterAppearance;
                break;

            case 2:
                currentCharacterAppearance = _secondCharacterAppearance;
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }

        Sprite[] spriteSet = currentCharacterAppearance.GetSpiteSet(numberOfSpriteSet);

        for (int i = 0; i < spriteSet.Length; i++)
        {
            _clothingImages[i].sprite = spriteSet[i];
        }

        _modelTogglers.ChangeToggleValue(true, numberOfCharacterAppearance, false);
        _modelTogglers.ChangeToggleValue(false, numberOfCharacterAppearance == 1? 2 : 1, false);
    }

    private void OnModelChanged()
    {
        if (_isEnableDefaulReser == false)
            return;

        ChangeTogglersToDefault();
        ChangeSpriteSet(true);
    }

    private void ChangeTogglersToDefault()
    {
        _modelTogglers.ChangeToggleValue(true, 1);
        _modelTogglers.ChangeToggleValue(false, 2);
    }

    public void SetDefaulReset(bool value)
    {
        _isEnableDefaulReser = value;   
    }
}
