using UnityEngine;

public class ClothingHintSystem : HintSystem
{
    [SerializeField] private ClothingSlot[] _clothingSlots;

    private void OnEnable()
    {
        foreach (var slot in _clothingSlots)
        {
            slot.WrongClothingSelected += OnWrongSelected;
        }  
       
        foreach (var slot in _clothingSlots)
        {
            slot.CorrectClothingSelected += OnCorrectSelected;
        }
    }

    private void OnDisable()
    {
        foreach (var slot in _clothingSlots)
        {
            slot.WrongClothingSelected -= OnWrongSelected;
        }

        foreach (var slot in _clothingSlots)
        {
            slot.CorrectClothingSelected -= OnCorrectSelected;
        }
    }
}