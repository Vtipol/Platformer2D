using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    [Header("Vars")]
    [SerializeField] private Slider _slider;

    [SerializeField] private FloatVar _minAudioValue;
    [SerializeField] private FloatVar _maxAudioValue;

    [SerializeField] private AudioMixerGroup _mixerGroup;
    [SerializeField] private AudioMixer _audioMixer;

    [Header("Events")]
    [SerializeField] private UnityEvent OnMute;
    [SerializeField] private UnityEvent OnUnmute;

    private const string VOLUME = "Volume";

    private float _value;
    private float _beforeMuteValue;

    private void Awake()
    {
        LoadValue();
        SetUpSlider();
    }

    private void Start()
    {
        // Update the value in Start,
        // if done on Awake AudioMixer won't be ready and setting the Volume won't work
        UpdateValue(_value);
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(UpdateValue);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(UpdateValue);
    }

    private void LoadValue()
    {
        if (!PlayerPrefs.HasKey(_mixerGroup.name))
        {
            if (_audioMixer.GetFloat(_mixerGroup.name + VOLUME, out float volume))
            {
                _value = volume;
                PlayerPrefs.SetFloat(_mixerGroup.name, _value);
                PlayerPrefs.Save();
            }
        }
        else
        {
            _value = PlayerPrefs.GetFloat(_mixerGroup.name);
        }
    }

    private void SetUpSlider()
    {
        _slider.minValue = _minAudioValue.Value;
        _slider.maxValue = _maxAudioValue.Value;
        _slider.value = _value;
    }

    private void UpdateValue(float value)
    {
        _value = value;
        bool result = _audioMixer.SetFloat(_mixerGroup.name + VOLUME, value);

        if (!result)
        {
            Debug.LogWarning("Property: " + _mixerGroup.name + VOLUME + " not found");
            return;
        }

        SaveValue();

        if (value == _minAudioValue.Value)
        {
            OnMute.Invoke();
        }
        else
        {
            OnUnmute.Invoke();
        }
    }

    public void SetValue(float value)
    {
        UpdateValue(value);
        _slider.value = value;
    }

    public void SetValue(FloatVar value)
    {
        UpdateValue(value.Value);
        _slider.value = value.Value;
    }

    public void Mute()
    {
        _beforeMuteValue = _value;
        SetValue(_minAudioValue);
    }

    public void Unmute()
    {
        SetValue(_beforeMuteValue);
    }

    private void SaveValue()
    {
        PlayerPrefs.SetFloat(_mixerGroup.name, _value);
        PlayerPrefs.Save();
    }
}
