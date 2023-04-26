using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HUDPresenter 
{
    public static event Action OnInventoryWindow;

    public static void TransformInventoryWindow()
    {
        OnInventoryWindow?.Invoke();
    }
}
