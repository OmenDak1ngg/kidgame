
using DG.Tweening;
using System.Collections;
using UnityEngine;

internal class Highlighter : MonoBehaviour
{
    [SerializeField] private int _pulseCount;
    [SerializeField] private float _maxThickness = 3f;
    [SerializeField] private float _pulseTime = 1f;

    private bool _isHighlighting;

    private Coroutine _coroutine;

    private void Awake()
    {
        _isHighlighting = false;
    }

    private void OnDisable()
    {
        _isHighlighting = false;
        if (_coroutine == null)
            return;
  
        StopCoroutine(_coroutine);    
    }

    private IEnumerator EnablePulses(HighlightObject obj)
    {
        obj.Highlight();
        Tween pulseTween = DOTween.To(
            () => obj.GetOutlineWidth(),          
            x => obj.SetOutlineWidth(x),          
            _maxThickness,                         
            _pulseTime / 2f                    
        )
        .SetLoops(_pulseCount * 2, LoopType.Yoyo) 
        .SetEase(Ease.InOutQuad);                

        yield return pulseTween.WaitForCompletion();

        obj.SetOutlineWidth(0f);
        obj.Dehighlight();
        _isHighlighting = false;
    }

    public void StartPulses(HighlightObject obj)
    {
        if (_isHighlighting)
            return;

        _isHighlighting = true;
        _coroutine = StartCoroutine(EnablePulses(obj));
    }

}
