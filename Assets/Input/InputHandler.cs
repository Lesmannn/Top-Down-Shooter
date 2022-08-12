using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "Input Handler", menuName = "Input Handler")]

public class InputHandler : ScriptableObject, Input.IGameplayActions
{
	private Input input;
	public UnityAction<Vector2> OnKeyAction;
	public UnityAction OnPauseAction;

	private void OnEnable()
	{
		if (input == null)
		{
			input = new Input();
		}
		input.Gameplay.SetCallbacks(this);
		input.Gameplay.Enable();
	}
	private void OnDisable()
	{
		input.Gameplay.Disable();
	}

	public void OnKey(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Performed || context.phase == InputActionPhase.Canceled)
		{
			OnKeyAction?.Invoke(context.ReadValue<Vector2>());
		}
	}
	public void OnPause(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Performed)
		{
			OnPauseAction?.Invoke();
		}
	}
}
