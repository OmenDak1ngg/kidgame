using UnityEngine;

public class HintSystem : MonoBehaviour
{
    [SerializeField] private int _maxWrongAttemts = 3;

    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private Highlighter _highlighter;
    [SerializeField] protected ClothingOrder Order;

    private int _wrongAttempts;
    
    private void Awake()
    {
        _wrongAttempts = 0;
    }

    protected virtual void OnWrongSelected()
    {
        _wrongAttempts++;
        _wrongAttempts %= _maxWrongAttemts;

        switch (_wrongAttempts)
        {
            case 1:
                PlayVoiceHint();
                break;

            case 2:
                HighlightCorrectObject();
                break;

            case 0:
                DressAutomatically();
                _wrongAttempts = 0;
                break;
        }
    }

    protected virtual void OnCorrectSelected()
    {
        _wrongAttempts = 0;
    }

    protected virtual void DressAutomatically()
    {
        Debug.Log("одежда сама наделась на слот");
    }

    protected virtual void HighlightCorrectObject()
    {
        _highlighter.StartPulses(Order.GetCorrectClothing());
    }

    protected virtual void HighlightCorrectObject(HighlightObject obj)
    {
        _highlighter.StartPulses(obj);
    }

    protected virtual void PlayVoiceHint()
    {
        _audioSource.Play();
    }
}
