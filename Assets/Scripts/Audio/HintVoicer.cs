using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class HintVoicer : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audioClips;
    [SerializeField] private ToggleGroup _toggleGroup;

    private AudioSource _audioSource;

    private void OnEnable()
    {
        _toggleGroup.ToggleChanged += ChangeClip;
    }

    private void OnDisable()
    {
        _toggleGroup.ToggleChanged -= ChangeClip;
    }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void ChangeClip(int indexOfClip)
    {
        _audioSource.clip = _audioClips[indexOfClip];
    }
}
