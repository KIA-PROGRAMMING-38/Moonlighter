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
                    ChangeState(animator, WeaponAnimParamsToHash.ONSECONDARYACTION, WeaponAnimParamsToHash.IDLE);
                }
                if (inputHandler.MoveInput != Vector2.zero)
                {
                    ChangeState(animator, WeaponAnimParamsToHash.ONSECONDARYACTION, WeaponAnimParamsToHash.SECONDARYACTION);
                }
                break;
            case Weapons.BigSword:
                if (false == inputHandler.SecondaryActionInput)
                {
                    ChangeState(animator, WeaponAnimParamsToHash.ONSECONDARYACTION, WeaponAnimParamsToHash.SECONDARYACTION);
                }
                break;
        }
    }
}
