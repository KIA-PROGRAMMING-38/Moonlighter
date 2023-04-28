using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIInputHandler : MonoBehaviour
{
    public bool OnInventoryWindow { get; private set; }

    public Vector2 CursorInput { get; private set; }

    public void OnInventoryKey(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            HUDPresenter.TransformInventoryWindow();
            OnInventoryWindow = !OnInventoryWindow;
        }
    }

    public void OnCursorMove(InputAction.CallbackContext context)
    {
        if(Time.timeScale == 0f)
        {
            if(context.performed)
            {
                CursorInput = context.ReadValue<Vector2>();
                InventoryPresenter.ModifyCursorPosition();
            }
        }
    }

    public void OnPickingKey(InputAction.CallbackContext context)
    {
        if(Time.timeScale == 0f)
        {
            if(context.performed)
            {
                InventoryPresenter.ActicePickedItemSlot();
            }
        }
    }

    public void OnQuickEquipKey(InputAction.CallbackContext context)
    {
        if(Time.timeScale == 0f)
        {
            if (context.performed)
            {
                InventoryPresenter.RegisterQuickSlot();
            }
        }
    }




}
