using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    //Static For Easy Ref.
    public static PlayerInput PlayerInput;

    public static Vector2 Movement;
    public static bool JumpWasPressed;
    public static bool JumpIsHeld;
    public static bool JumpWasRelesed;
    public static bool RunIsHeld;

    private InputAction _moveAction;
    private InputAction _jumpAction;
    private InputAction _runAction;

    private void Awake()
    {
        PlayerInput = GetComponent<PlayerInput>();

        _moveAction = PlayerInput.actions["Move"];
        _jumpAction = PlayerInput.actions["Jump"];
        _runAction = PlayerInput.actions["Sprint"];
    }

    private void Update()
    {
        Movement = _moveAction.ReadValue<Vector2>();

        JumpWasPressed = _jumpAction.WasPerformedThisFrame();
        JumpIsHeld = _jumpAction.IsPressed();
        JumpWasRelesed = _jumpAction.WasReleasedThisFrame();

        RunIsHeld = _runAction.IsPressed();
    }
}
