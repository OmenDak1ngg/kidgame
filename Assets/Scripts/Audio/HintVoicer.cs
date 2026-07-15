using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class HintVoicer : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audioClips;
    [SerializeField] private ToggleGroup _toggleGroup;
    [SerializeField] private UIButton _activateButton;

    private AudioSource _audioSource;

    private void OnEnable()
    {
        _toggleGroup.ToggleChanged += ChangeClip;
        _activateButton.Clicked += Play;
    }

    private void OnDisable()
    {
        _toggleGroup.ToggleChanged -= ChangeClip;
        _activateButton.Clicked -= Play;
    }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Play()
    {
        _audioSource.Play();
    }

    private void ChangeClip(int indexOfClip)
    {
        _audioSource.clip = _audioClips[indexOfClip];
        SaveSystem.SaveVoiceHintIndex(indexOfClip);
    }
}
