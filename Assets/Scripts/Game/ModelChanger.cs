using System;
using UnityEngine;
using UnityEngine.UI;

public class ModelChanger : MonoBehaviour
{
    [SerializeField] private Sprite _maleSprite;
    [SerializeField] private Sprite _femaleSprite;

    [SerializeField] private Image _kidImage;

    [SerializeField] private ModelTogglers _modelTogglers;

    public event Action ModelChanged;

    private void OnEnable()
    {
        _modelTogglers.MaleModelChoosed += OnModelChanged;
    }

    private void OnDisable()
    {
        _modelTogglers.MaleModelChoosed -= OnModelChanged;  
    }

    private void OnModelChanged(bool value)
    {
        Sprite currentSprite = value ? _maleSprite : _femaleSprite;

        _kidImage.sprite = currentSprite;

        ModelChanged?.Invoke();
    }
}
