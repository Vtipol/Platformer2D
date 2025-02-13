using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = nameof(AudioClipGroup),menuName = nameof(ScriptableObject)
    + "/" + nameof(AudioClipGroup)
    )]

public class AudioClipGroup : ScriptableObject
{
    [SerializeField] protected AudioClip _clip;
    [SerializeField] protected AudioMixerGroup _group;

    public virtual AudioClip Clip { get { return _clip; } }
    public virtual AudioMixerGroup Group { get { return _group; } }

}
