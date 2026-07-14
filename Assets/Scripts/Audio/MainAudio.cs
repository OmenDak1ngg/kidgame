using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MainAudio : MonoBehaviour
{
    [SerializeField] private UISlider _slider;

    private AudioSource _audioSource;

    public float Volume => _audioSource.volume;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _slider.ValueChanged += ChangeVolume;
    }

    private void OnDisable()
    {
        _slider.ValueChanged -= ChangeVolume;   
    }

    public void ChangeVolume(float value)
    {
        _audioSource.volume = value;
        SaveSystem.SaveMainVolume(value);
    }
}
