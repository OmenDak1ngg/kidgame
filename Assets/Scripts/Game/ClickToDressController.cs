using System;
using UnityEngine;


public class ClickToDressController : MonoBehaviour
{
    [SerializeField] private DragDrop[] _clothings;
    [SerializeField] private ClothingSlot[] _slots;

    private DragDrop _selectedClothing;
    private ClothingSlot _selectedSlot;

    private void OnEnable()
    {
        foreach (var slot in _slots)
        {
            slot.Clicked += OnSlotClicked;
        }

        foreach(var clothing in _clothings)
        {
            clothing.Clicked += OnClothingClicked;
        }
    }


    private void OnDisable()
    {
        foreach (var slot in _slots)
        {
            slot.Clicked -= OnSlotClicked;
        }

        foreach (var clothing in _clothings)
        {
            clothing.Clicked -= OnClothingClicked;
        }
    }
    private void OnClothingClicked(DragDrop clothing)
    {
        _selectedClothing = clothing;
    }

    private void OnSlotClicked(ClothingSlot slot)
    {
        if (_selectedClothing == null)
            return;

        _selectedSlot = slot;

        MoveClothingToSlot(_selectedClothing, _selectedClothing);
    }

    private void MoveClothingToSlot(DragDrop selectedClothing1, DragDrop selectedClothing2)
    {
        _selectedSlot.OnCorrectClick(_selectedClothing.GetComponent<Clothing>());
    }
}