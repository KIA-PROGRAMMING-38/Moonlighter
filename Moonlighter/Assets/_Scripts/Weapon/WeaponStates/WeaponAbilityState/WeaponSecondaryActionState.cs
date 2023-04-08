using EnumValue;
using UnityEngine;

public class WeaponSecondaryActionState : WeaponAbilityState
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player.CurrentState == PlayerStates.Idle)
        {
            ChangeState(animator, WeaponAnimParams.SECONDARYACTION, WeaponAnimParams.IDLE);
        }

        if (player.CurrentState == PlayerStates.OnSecondaryAction)
        {
            ChangeState(animator, WeaponAnimParams.SECONDARYACTION, WeaponAnimParams.ONSECONDARYACTION);
        }
    }
}
