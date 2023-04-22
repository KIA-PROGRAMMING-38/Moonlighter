using System;

public static class MonsterPresenter
{
    public static event Action<int, int> OnChangedMonsterHPRatio;

    public static void ModifyPlayerHPRatio(int maxHp, int curHp)
    {
        OnChangedMonsterHPRatio?.Invoke(maxHp, curHp);
    }
}
