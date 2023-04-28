using System;

public static class InventoryPresenter
{
    public static event Action OnMoveCursor;

    public static event Action<ItemData> OnGoToInventory;

    public static void ModifyCursorPosition()
    {
        OnMoveCursor?.Invoke();
    }

    public static void StoreInInventory(ItemData data)
    {
        OnGoToInventory?.Invoke(data);
    }
}
