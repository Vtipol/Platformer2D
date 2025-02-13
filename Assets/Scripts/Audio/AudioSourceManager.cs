using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class AudioSourceManager : MonoBehaviour
{
    public static AudioSourceManager Instance { get; private set; }

    [SerializeField] private AudioMixer _audioMixer;

    private Dictionary<AudioMixerGroup, AudioSource> _groupSource;

    public static UnityAction<AudioClip, AudioMixerGroup> OnPlayAudioClip;
    public static UnityAction<AudioClipGroup> OnPlayClipGroup;


    public static UnityAction<AudioClip, AudioMixerGroup> OnPlayLoopAudioClip;
    public static UnityAction<AudioClipGroup> OnPlayLoopClipGroup;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadAudioGroupsSources();

        AddListeners();
    }

    private void OnDestroy()
    {
        RemoveListeners();
    }

    private void AddListeners()
    {
        OnPlayAudioClip += PlayOnce;
        OnPlayClipGroup += PlayOnce;

        OnPlayLoopAudioClip += PlayLoop;
        OnPlayLoopClipGroup += PlayLoop;
    }

    private void RemoveListeners()
    {
        OnPlayAudioClip -= PlayOnce;
        OnPlayClipGroup -= PlayOnce;

        OnPlayLoopAudioClip -= PlayLoop;
        OnPlayLoopClipGroup -= PlayLoop;
    }

    // Fills the dictionary of AudioMixerGroups and AudioSources
    // by getting all of the groups from the AudioMixer,
    // then creating an AudioSource for each of the mixers and assigning it
    // the mixer through which they should output the sound
    private void LoadAudioGroupsSources()
    {
        _groupSource = new();

        AudioMixerGroup[] audioMixerGroups = _audioMixer.FindMatchingGroups("");

        for (int i = 0; i < audioMixerGroups.Length; i++)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.outputAudioMixerGroup = audioMixerGroups[i];

            _groupSource[audioMixerGroups[i]] = audioSource;
        }
    }

    private void PlayOnce(AudioClip audioClip, AudioMixerGroup group)
    {
        // Check audioClip and group validity
        if (!IsAudioClipGroupValid(audioClip, group))
            return;

        AudioSource audioSource = _groupSource[group];
        audioSource.PlayOneShot(audioClip);
    }

    private void PlayOnce(AudioClipGroup clipGroup)
    {
        // Check audioClip and group validity
        if (!IsAudioClipGroupValid(clipGroup))
            return;

        AudioSource audioSource = _groupSource[clipGroup.Group];
        audioSource.PlayOneShot(clipGroup.Clip);
    }

    private void PlayLoop(AudioClipGroup clipGroup)
    {
        // Check audioClip and group validity
        if (!IsAudioClipGroupValid(clipGroup))
            return;

        AudioSource audioSource = _groupSource[clipGroup.Group];
        audioSource.clip = clipGroup.Clip;
        audioSource.loop = true;
        audioSource.Play();
    }

    private void PlayLoop(AudioClip audioClip, AudioMixerGroup group)
    {
        // Check audioClip and group validity
        if (!IsAudioClipGroupValid(audioClip, group))
            return;

        AudioSource audioSource = _groupSource[group];
        audioSource.clip = audioClip;
        audioSource.loop = true;
        audioSource.Play();
    }

    private bool IsAudioClipGroupValid(AudioClipGroup clipGroup)
    {
        if (!clipGroup.Clip || !clipGroup.Group)
        {
            string errorMessage = "Make sure clip group: " + clipGroup.name + "'s ";

            if (!clipGroup.Clip)
            {
                errorMessage += "audioClip";
                if (!clipGroup.Group)
                {
                    errorMessage += "and audioMixerGroup are valid";
                    Debug.LogError(errorMessage);
                    return false;
                }
            }
            else
            {
                errorMessage += "audioMixerGroup";
            }

            errorMessage += " is valid";

            Debug.LogError(errorMessage);
            return false;
        }

        return true;
    }

    private bool IsAudioClipGroupValid(AudioClip audioClip, AudioMixerGroup group)
    {
        if (!audioClip || !group)
        {
            string errorMessage = "Make sure ";

            if (!audioClip)
            {
                errorMessage += "audioClip";
                if (!group)
                {
                    errorMessage += "and audioMixerGroup are valid";
                    Debug.LogError(errorMessage);
                    return false;
                }
            }
            else
            {
                errorMessage += "audioMixerGroup";
            }

            errorMessage += " is valid";

            Debug.LogError(errorMessage);
            return false;
        }

        return true;
    }

    public void TransitionToSnapshot(AudioMixerSnapshot snapshot, float transitionTime)
    {
        snapshot.TransitionTo(transitionTime);
    }

    public void TransitionToSnapshot(SnapshotTime snapshotTime)
    {
        snapshotTime.Snapshot.TransitionTo(snapshotTime.TransitionDuration);
    }
}
