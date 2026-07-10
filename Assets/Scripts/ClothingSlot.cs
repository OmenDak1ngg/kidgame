using System;
using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(RectTransform))]
public class ClothingSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private ClothingTypes _allowedType;

    private RectTransform _rectTransform;

    public event Action<Clothing> WrongClothingSelected;
    public event Action CorrectClothingSelected;

    public event Action<ClothingSlot, Clothing> ClothingSelected;
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent<Clothing>(out Clothing clothing) == false)
            return;

        if (clothing.Type != _allowedType)
        {
            WrongClothingSelected?.Invoke(clothing);
            return;
        }

        ClothingSelected?.Invoke(this, clothing);
    }

    public void OnCorrectClothingSelected(Clothing clothing)
    {
        clothing.GetComponent<RectTransform>().position = _rectTransform.position;
        clothing.GetComponent<DragDrop>().SetEquiped(true);

        CorrectClothingSelected?.Invoke();
    }
}