using System;

public static class HUDPresenter 
{
    public static event Action OnInventoryWindow;

    public static event Action OnRegistQuickSlot;

    public static event Action OnUnRegistQuickSlot;
    
    public static void TransformInventoryWindow()
    {
        OnInventoryWindow?.Invoke();
    }

    public static void RegistQuickSlot()
    {
        OnRegistQuickSlot?.Invoke();
    }

    public static void UnRegistQuickSlot()
    {
        OnUnRegistQuickSlot?.Invoke();
    }
}
