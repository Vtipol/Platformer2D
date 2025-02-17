using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StateDrivenEvent : MonoBehaviour
{
    [SerializeField] private List<StateEvent> _stateEventsList;

    private Dictionary<State, UnityEvent> _stateEvents;

    private State _currentState;

    private void Awake()
    {
        FillDictionary();
    }

    // Translates the List to a Dictionary for quicker access
    private void FillDictionary()
    {
        _stateEvents = new();

        for (int i = 0; i < _stateEventsList.Count; i++)
        {
            StateEvent stateEvent = _stateEventsList[i];
            if (stateEvent.State == null || stateEvent.UnityEvent == null)
            {
                Debug.LogWarning("A StateEvent in StateDrivenEvent in " + gameObject.name + " is not valid");
                break;
            }
            _stateEvents[stateEvent.State] = stateEvent.UnityEvent;
        }
    }

    public void Invoke()
    {

        if (!_currentState || !_stateEvents.ContainsKey(_currentState))
        {
            Debug.LogWarning("State doesn't exist or is null!");
            return;
        }

        if (_currentState != null)
        {
            _stateEvents[_currentState].Invoke();
        }
    }

    public void SetState(State state)
    {
        _currentState = state;
    }
}
