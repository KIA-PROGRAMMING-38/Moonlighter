using UnityEngine;
using Enums;

public class GolemSoldier : Monster
{
    protected override void Awake()
    {
        base.Awake();
        Stat = Managers.Data.CharacterStatDataTable[(int)CharacterStatId.GolemSoldier];
    }
}