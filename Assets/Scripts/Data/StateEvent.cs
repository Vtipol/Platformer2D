using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public record StateEvent
{
    public State State;
    public UnityEvent UnityEvent;
}
