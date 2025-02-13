using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class PlayAudio : MonoBehaviour
{
    public void Play(AudioClipGroup clipGroup) { 
        AudioSourceManager.OnPlayClipGroup(clipGroup);
    }

    public void Play(AudioClip audioClip, AudioMixerGroup group)
    {
        AudioSourceManager.OnPlayAudioClip(audioClip, group);
    }

    public void PlayLoop(AudioClipGroup clipGroup)
    { 
        AudioSourceManager.OnPlayLoopClipGroup(clipGroup);
    }

    public void PlayLoop(AudioClip audioClip, AudioMixerGroup group) { 
        AudioSourceManager.OnPlayLoopAudioClip(audioClip, group);
    }
}
