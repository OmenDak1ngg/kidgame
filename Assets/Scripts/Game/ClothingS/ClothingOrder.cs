using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ClothingOrder : MonoBehaviour
{
    [SerializeField] private List<ClothingSlot> _slots;
    [SerializeField] private List<Clothing> _clothings;

    private int _currentIndex;

    public event Action SelectedCorrectClothing;
    public event Action SelectedWrongClothing;

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
            SelectedWrongClothing?.Invoke();
            return;
        }

        _currentIndex++;
        slot.OnCorrectClothingSelected(clothing);
        SelectedCorrectClothing?.Invoke();
    }

    public ClothingSlot GetCorrcetSlot()
    {
        return _slots[_currentIndex];
    }

    public Clothing GetCorrectClothing()
    {
        return _clothings.FirstOrDefault(clothing => clothing.Type == _slots[_currentIndex].AllowedType);
    }

    public void IncreaseIndex()
    {
        _currentIndex++;
    }
}