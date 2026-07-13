using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using System;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(CanvasGroup))]
   
public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler
{
    [SerializeField] private Canvas _canvas;

    [SerializeField] private RectTransform _startPosition;

    [SerializeField] private float _returnDuration = 1f;

    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;

    private bool _isEquiped;

    public event Action<DragDrop> Clicked;

    private void Awake()
    {
        _isEquiped = false;
        _rectTransform = GetComponent<RectTransform>();
        _rectTransform.position = _startPosition.position;
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (PauseManager.IsPaused)
            return;

        _canvasGroup.alpha = 0.6f;
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_isEquiped || PauseManager.IsPaused)
            return;

        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (PauseManager.IsPaused)
            return;

        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.alpha = 1f;

        if(_isEquiped)
            return;

        Vector2 onDropPosition = _rectTransform.position;

        _rectTransform.DOAnchorPos(_startPosition.position, _returnDuration);
    }

    public void SetEquiped(bool value)
    {
        _isEquiped = value;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Clicked?.Invoke(this);
    }
}
