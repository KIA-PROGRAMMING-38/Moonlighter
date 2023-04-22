using System;

public static class PlayerPresenter
{
    public static event Action<int, int> OnChangedPlayerHPRatio; 


    public static void ModifyPlayerHPRatio(int maxHp, int curHp)
    {
        OnChangedPlayerHPRatio?.Invoke(maxHp, curHp);
    }
}
