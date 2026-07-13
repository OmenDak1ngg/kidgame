using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MainAudio : MonoBehaviour
{
    [SerializeField] private UISlider _slider;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _slider.ChangeValue(_audioSource.volume);
    }

    private void OnEnable()
    {
        _slider.ValueChanged += ChangeVolume;
    }

    private void OnDisable()
    {
        _slider.ValueChanged -= ChangeVolume;   
    }

    private void ChangeVolume(float value)
    {
        _audioSource.volume = value;        
    }
}
