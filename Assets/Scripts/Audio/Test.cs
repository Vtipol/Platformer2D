using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private AudioClipGroup _audioClipGroup;
    [SerializeField] private AudioClipGroup _audioClipGroup2;

    // Start is called before the first frame update
    void Start()
    {
        AudioSourceManager.OnPlayLoopClipGroup.Invoke(_audioClipGroup);
        AudioSourceManager.OnPlayLoopClipGroup.Invoke(_audioClipGroup2);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
