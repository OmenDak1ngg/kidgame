using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(RectTransform))]
public class ClothingSlot : MonoBehaviour, IDropHandler, IPointerClickHandler, IHiglightable
{
    [SerializeField] private ClothingTypes _allowedType;
    [SerializeField] private bool _isClickMode = true;


    private RectTransform _rectTransform;

    public event Action<Clothing> WrongClothingSelected;
    public event Action CorrectClothingSelected;
    public event Action<ClothingSlot, Clothing> ClothingSelected;

    public event Action<ClothingSlot> Clicked;

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

    //переназвать потом
    public void OnCorrectClick(Clothing clothing)
    {
        if (clothing.Type != _allowedType)
        {
            WrongClothingSelected?.Invoke(clothing);
            return;
        }

        ClothingSelected?.Invoke(this, clothing);
    }

    public void OnCorrectClothingSelected(Clothing clothing)
    {
        if (_isClickMode)
            clothing.GetComponent<RectTransform>().DOAnchorPos(_rectTransform.anchoredPosition, 1f);
        else
            clothing.GetComponent<RectTransform>().position = _rectTransform.position;

        clothing.GetComponent<DragDrop>().SetEquiped(true);
        CorrectClothingSelected?.Invoke();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Clicked?.Invoke(this);
    }

    private void OnDrawGizmos()
    {
        if (_rectTransform == null)
            _rectTransform = GetComponent<RectTransform>();

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_rectTransform.position, new Vector3(_rectTransform.rect.width, _rectTransform.rect.height, 0f));
    }
}