using EnumValue;
using UnityEngine;

public class WeaponOnSecondaryActionState : WeaponAbilityState
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        switch (player.CurrentPrimaryWeapon)
        {
            case Weapons.ShortSwordAndShield:
                if (false == inputHandler.SecondaryActionInput)
                {
                    ChangeState(animator, WeaponAnimParams.ONSECONDARYACTION, WeaponAnimParams.IDLE);
                }
                if (inputHandler.MoveInput != Vector2.zero)
                {
                    ChangeState(animator, WeaponAnimParams.ONSECONDARYACTION, WeaponAnimParams.SECONDARYACTION);
                }
                break;
            case Weapons.BigSword:
                if (false == inputHandler.SecondaryActionInput)
                {
                    ChangeState(animator, WeaponAnimParams.ONSECONDARYACTION, WeaponAnimParams.SECONDARYACTION);
                }
                break;
        }
    }
}
