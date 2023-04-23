using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WeaponPresenter
{
    public static event Action OnChangeWeapon;

    public static void ChangeWeapon()
    {
        OnChangeWeapon?.Invoke();
    }
}
