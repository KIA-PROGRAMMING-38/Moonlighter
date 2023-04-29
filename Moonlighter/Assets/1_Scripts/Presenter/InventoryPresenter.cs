using System;

public static class InventoryPresenter
{
    public static event Action OnMoveCursor;

    public static event Action<ItemData> OnGoToInventory;

    public static event Action OnGoToQuickSlot;

    public static event Action OnPickedUpItemSlot;

    public static event Action OnPickedDownItemSlot;

    public static event Action OnUseQuickSlot;

    public static void ModifyCursorPosition()
    {
        OnMoveCursor?.Invoke();
    }

    public static void StoreInInventory(ItemData data)
    {
        OnGoToInventory?.Invoke(data);
    }

    public static void RegisterQuickSlot()
    {
        OnGoToQuickSlot?.Invoke();
    }

    public static void ActicePickedItemSlot()
    {
        OnPickedUpItemSlot?.Invoke();
    }

    public static void InActivePickedItemSlot()
    {
        OnPickedDownItemSlot?.Invoke();
    }

    public static void UseQuickSlot()
    {
        OnUseQuickSlot?.Invoke();
    }
}
