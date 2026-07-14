using System.Collections;
using UnityEngine;

public class SlotHintSystem : HintSystem
{
    [SerializeField] private ClothingOrder _order;


    private void OnEnable()
    {
        _order.SelectedCorrectClothing += OnCorrectSelected;
        _order.SelectedWrongClothing += OnWrongSelected;
    }

    private void OnDisable()
    {
        _order.SelectedCorrectClothing -= OnCorrectSelected;
        _order.SelectedWrongClothing -= OnWrongSelected;
    }

}