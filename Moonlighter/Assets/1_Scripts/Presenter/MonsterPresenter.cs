using System;

public class MonsterPresenter
{
    public event Action<int, int> OnChangedMonsterHPRatio;
    public event Action OnDie;

    public void ModifyMonsterHPRatio(int maxHp, int curHp)
    {
        OnChangedMonsterHPRatio?.Invoke(maxHp, curHp);
    }

    public void NotifyMonsterDie()
    {
        OnDie?.Invoke();
    }
}
