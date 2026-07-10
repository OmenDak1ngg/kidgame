using System.Collections;
using UnityEngine;

public class SlotHintSystem : MonoBehaviour
{
    [SerializeField] private ClothingOrder _order;

    private int _wrongAttempts;

    private int _maxWrongAttemts = 3;

    private void OnEnable()
    {
        _order.SelectedCorrectClothing += OnCorrectClothingSelected;
        _order.SelectedWrongClothing += OnWrongClothingSelected;
    }

    private void OnDisable()
    {
        _order.SelectedCorrectClothing -= OnCorrectClothingSelected;
        _order.SelectedWrongClothing -= OnWrongClothingSelected;
    }

    private void Awake()
    {
        _wrongAttempts = 0;
    }

    public void OnWrongClothingSelected(ClothingSlot slot)
    {
        _wrongAttempts++;
        _wrongAttempts %= _maxWrongAttemts;

        switch (_wrongAttempts)
        {
            case 1:
                PlayVoiceHint();
                break;

            case 2:
                HighlightCorrectSlot();
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
        Debug.Log("одежда сама наделась на слот");
    }

    private void HighlightCorrectSlot()
    {
        Debug.Log("подсветился нужный слот");
    }

    private void PlayVoiceHint()
    {
        Debug.Log("проигралась аудиоподсказка для слота");
    }
}