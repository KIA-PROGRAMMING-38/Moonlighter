using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPresenter
{
    public static event Action<int, int> OnChangedPlayerHPRatio; 


    public static void ModifyPlayerHPRatio(int maxHp, int curHp)
    {
        OnChangedPlayerHPRatio?.Invoke(maxHp, curHp);
    }
}
