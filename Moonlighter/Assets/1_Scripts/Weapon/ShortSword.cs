using Enums;
using UnityEngine;

public class ShortSword : Weapon
{
    public override void Init(WeaponId weaponId)
    {
        data = Managers.Data.WeaponDataTable[(int)weaponId];
    }

    public override void NormalAttack()
    {
        Debug.Log("NormalAttack");
    }
}