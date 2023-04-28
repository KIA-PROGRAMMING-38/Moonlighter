using System;

public static class HUDPresenter 
{
    public static event Action OnInventoryWindow;

    
    public static void TransformInventoryWindow()
    {
        OnInventoryWindow?.Invoke();
    }

    
}
