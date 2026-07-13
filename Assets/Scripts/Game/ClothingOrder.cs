using System;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class ClothingOrder : MonoBehaviour
{
    [SerializeField] private List<ClothingSlot> _slots;

    private int _currentIndex;

    public event Action SelectedCorrectClothing;
    public event Action<ClothingSlot> SelectedWrongClothing;

    private void OnEnable()
    {
        foreach (ClothingSlot slot in _slots)
        {
            slot.ClothingSelected += OnClothingSelected;
        }
    }

    private void OnDisable()
    {
        foreach (ClothingSlot slot in _slots)
        {
            slot.ClothingSelected -= OnClothingSelected;
        }       
    }

    private void Awake()
    {
        _currentIndex = 0;
    }
    
    private void OnClothingSelected(ClothingSlot slot, Clothing clothing)
    {
        if (_slots[_currentIndex] != slot)
        {
            SelectedWrongClothing?.Invoke(slot);
            return;
        }

        _currentIndex++;
        slot.OnCorrectClothingSelected(clothing);
        SelectedCorrectClothing?.Invoke();
    }
}