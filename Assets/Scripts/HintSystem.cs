using System;
using UnityEngine;

public class HintSystem : MonoBehaviour
{
    [SerializeField] private ClothingSlot[] _clothingSlots;

    private int _wrongAttempts;

    private int _maxWrongAttemts = 3;

    private void OnEnable()
    {
        foreach (var slot in _clothingSlots)
        {
            slot.WrongClothingSelected += OnWrongClothingSelected;
        }  
       
        foreach (var slot in _clothingSlots)
        {
            slot.CorrectClothingSelected += OnCorrectClothingSelected;
        }
    }

    private void OnDisable()
    {
        foreach(var slot in _clothingSlots)
        {
            slot.WrongClothingSelected -= OnWrongClothingSelected;
        } 
        
        foreach(var slot in _clothingSlots)
        {
            slot.CorrectClothingSelected -= OnCorrectClothingSelected;
        }
    }


    private void Awake()
    {
        _wrongAttempts = 0;
    }

    public void OnWrongClothingSelected(Clothing clothing)
    {
        _wrongAttempts++;
        _wrongAttempts %= _maxWrongAttemts;

        switch (_wrongAttempts)
        {
            case 1:
                PlayVoiceHint();
                break;

            case 2:
                HighlightCorrectClothes();
                break;

            case 0:
                DressAutomatically();
                _wrongAttempts = 0;
                break;
        }
    }

    private void OnCorrectClothingSelected()
    {
        _wrongAttempts = 0;
    }

    private void DressAutomatically()
    {
        Debug.Log("одежда сама наделась");
    }

    private void HighlightCorrectClothes()
    {
        Debug.Log("подсветилась нужна одежда");
    }

    private void PlayVoiceHint()
    {
        Debug.Log("проигралась аудиоподсказка");
    }
}