using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InventoryPresenter
{
    public static event Action OnMoveCursor;

    public static void ModifyCursorPosition()
    {
        OnMoveCursor?.Invoke();
    }
}
