using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WeaponAnimParamsToHash 
{
    public static readonly int DIRX = Animator.StringToHash(WeaponAnimParams.DIRX);
    public static readonly int DIRY = Animator.StringToHash(WeaponAnimParams.DIRY);
    public static readonly int IDLE = Animator.StringToHash(WeaponAnimParams.IDLE);
    public static readonly int COMBOATTACKONE = Animator.StringToHash(WeaponAnimParams.COMBOATTACKONE);
    public static readonly int COMBOATTACKTWO = Animator.StringToHash(WeaponAnimParams.COMBOATTACKTWO);
    public static readonly int COMBOATTACKTHREE = Animator.StringToHash(WeaponAnimParams.COMBOATTACKTHREE);
    public static readonly int READYSECONDARYACTION = Animator.StringToHash(WeaponAnimParams.READYSECONDARYACTION);
    public static readonly int ONSECONDARYACTION = Animator.StringToHash(WeaponAnimParams.ONSECONDARYACTION);
    public static readonly int SECONDARYACTION = Animator.StringToHash(WeaponAnimParams.SECONDARYACTION);
}
