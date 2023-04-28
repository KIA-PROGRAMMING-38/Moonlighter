using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Data/Item Data/Weapon Data/Base Data")]
public class WeaponData : ItemData
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
