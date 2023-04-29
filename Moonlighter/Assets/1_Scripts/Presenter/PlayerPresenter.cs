using System;

public static class PlayerPresenter
{
    public static event Action<int, int> OnChangedPlayerHPRatio;
    public static event Action<int, int> OnUsePotion;

    public static void ModifyPlayerHPRatio(int maxHp, int curHp)
    {
        OnChangedPlayerHPRatio?.Invoke(maxHp, curHp);
    }

    public static void UsePotion(int maxHp, int curHp)
    {
        OnUsePotion?.Invoke(maxHp, curHp);
    }
}
