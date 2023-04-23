using EnumValue;
using UnityEngine;

public class WeaponSecondaryActionState : WeaponAbilityState
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        switch (player.PrimaryWeapon)
        {
            case Weapons.ShortSwordAndShield:
                if (false == inputHandler.SecondaryActionInput)
                {
                    ChangeState(animator, WeaponAnimParamsToHash.SECONDARYACTION, WeaponAnimParamsToHash.IDLE);
                }
                if (inputHandler.MoveInput == Vector2.zero)
                {
                    ChangeState(animator, WeaponAnimParamsToHash.SECONDARYACTION, WeaponAnimParamsToHash.ONSECONDARYACTION);
                }
                break;
            case Weapons.BigSword:
                if (animHandler.IsAnimationEnded)
                {
                    ChangeState(animator, WeaponAnimParamsToHash.SECONDARYACTION, WeaponAnimParamsToHash.IDLE);
                }
                break;
        }

    }
}
