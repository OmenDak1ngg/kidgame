using UnityEngine;

public class SlotHintSystem : HintSystem
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

    protected override void HighlightCorrectObject()
    {
     //   base.HighlightCorrectObject(Order.GetCorrcetSlot().GetComponentInChildren<ClothingSlotImage>());
    }
}