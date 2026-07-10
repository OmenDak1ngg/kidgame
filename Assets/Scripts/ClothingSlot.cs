using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(RectTransform))]
public class ClothingSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private ClothingTypes _allowedType;

    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        eventData.pointerDrag.GetComponent<RectTransform>().position = _rectTransform.position;
        eventData.pointerDrag.GetComponent<DragDrop>().SetEquiped(true);
    }
}