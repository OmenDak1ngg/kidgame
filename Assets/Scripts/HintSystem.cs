
using UnityEngine;

public class HintSystem : MonoBehaviour
{
    [SerializeField] private int _wrongAttempts = 0;
    [SerializeField] private int _maxWrongAttemts = 3;

    [SerializeField] private AudioSource _audioSource;

    private void Awake()
    {
        _wrongAttempts = 0;
    }

    protected virtual void OnWrongSelected(IHiglightable obj)
    {
        _wrongAttempts++;
        _wrongAttempts %= _maxWrongAttemts;

        switch (_wrongAttempts)
        {
            case 1:
                PlayVoiceHint();
                break;

            case 2:
                HighlightCorrectSlot(obj);
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

    protected virtual void HighlightCorrectSlot(IHiglightable obj)
    {
        Debug.Log("подсветился нужный слот");
    }

    protected virtual void PlayVoiceHint()
    {
        _audioSource.Play();
    }
}
