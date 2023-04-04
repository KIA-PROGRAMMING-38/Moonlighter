using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }

    public bool RollInput { get; private set; }

    public bool ComboInput { get; private set; }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }

    public void OnRoll(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            RollInput = true;
        }
    }

    public void OnComboAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            ComboInput = true;
        }
    }

    public void UseRollInput() => RollInput = false;

    public void UseComboInput() => ComboInput = false;
}
