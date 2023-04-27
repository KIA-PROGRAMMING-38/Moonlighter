using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }

    public bool RollInput { get; private set; }

    public bool ComboInput { get; private set; }

    public bool WeaponComboInput { get; private set; }

    public bool SecondaryActionInput { get; private set; }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        if(Time.timeScale != 0)
        {
            MoveInput = context.ReadValue<Vector2>();
        }
    }

    public void OnRoll(InputAction.CallbackContext context)
    {
        if (context.started && Time.timeScale != 0)
        {
            RollInput = true;
        }
    }

    public void OnComboAttack(InputAction.CallbackContext context)
    {
        if (context.started && Time.timeScale != 0)
        {
            ComboInput = true;
            WeaponComboInput = true;
        }
    }

    public void OnSecondaryAction(InputAction.CallbackContext context)
    {
        if (context.started && Time.timeScale != 0)
        {
            SecondaryActionInput = true;
        }

        if (context.canceled)
        {
            SecondaryActionInput = false;
        }
    }

    public void OnWeaponChange(InputAction.CallbackContext context)
    {
        if(context.performed && Time.timeScale != 0)
        {
            WeaponPresenter.ChangeWeapon();
        }
    }

    public void UseRollInput() => RollInput = false;

    public void UseComboInput() => ComboInput = false;

    public void UseWeaponComboInput() => WeaponComboInput = false;
}
