using UnityEngine;

public class ClothingHintSystem : HintSystem
{
    private void OnEnable()
    {
        Order.SelectedWrongClothing += OnWrongSelected;
    }

    private void OnDisable()
    {
        Order.SelectedWrongClothing -= OnWrongSelected; 
    }
}