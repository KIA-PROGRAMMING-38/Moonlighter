using EnumValue;
using UnityEngine;

public class WeaponSecondaryActionState : WeaponAbilityState
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        switch (player.CurrentPrimaryWeapon)
        {
            case Weapons.ShortSwordAndShield:
                if (false == inputHandler.SecondaryActionInput)
                {
                    ChangeState(animator, WeaponAnimParams.SECONDARYACTION, WeaponAnimParams.IDLE);
                }
                if (inputHandler.MoveInput == Vector2.zero)
                {
                    ChangeState(animator, WeaponAnimParams.SECONDARYACTION, WeaponAnimParams.ONSECONDARYACTION);
                }
                break;
            case Weapons.BigSword:
                if (animHandler.IsAnimationEnded)
                {
                    ChangeState(animator, WeaponAnimParams.SECONDARYACTION, PlayerAnimParams.IDLE);
                }
                break;
        }

    }
}
