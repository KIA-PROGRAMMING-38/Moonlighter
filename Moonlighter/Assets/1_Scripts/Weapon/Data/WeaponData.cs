using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Data/Weapon Data/Base Data")]
public class WeaponData : ScriptableObject
{
    [Header("Combo State")]
    public int ComboAttackOneDamage;
    public int ComboAttackTwoDamage;
    public int ComboAttackThreeDamage;

    [Header("SecondaryAction State")]
    public int SecondaryActionDamage;

    [Header("Animator")]
    public RuntimeAnimatorController PlayerController;
    public RuntimeAnimatorController WeaponController;
}
