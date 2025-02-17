using UnityEngine;
using UnityEngine.Events;

public class LifeCycleEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent _onAwake;
    [SerializeField] private UnityEvent _onEnable;
    [SerializeField] private UnityEvent _onDisable;

    [SerializeField] private UnityEvent _onStart;
    
    [SerializeField] private UnityEvent _onUpdate;
    [SerializeField] private UnityEvent _onFixedUpdate;
    [SerializeField] private UnityEvent _onLateUpdate;

    private void Awake()
    {
        _onAwake.Invoke();
    }

    private void OnEnable()
    {
        _onEnable.Invoke();
    }

    private void OnDisable()
    {
        _onDisable.Invoke();
    }

    private void Start()
    {
        _onStart.Invoke();
    }

    private void Update()
    {
        _onUpdate.Invoke();
    }

    private void FixedUpdate()
    {
        _onFixedUpdate.Invoke();
    }

    private void LateUpdate()
    {
        _onLateUpdate.Invoke();
    }
}
