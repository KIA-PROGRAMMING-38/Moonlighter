using EnumValue;
using UnityEngine;

public class WeaponOnSecondaryActionState : WeaponAbilityState
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player.CurrentState == PlayerStates.SecondaryAction)
        {
            ChangeState(animator, WeaponAnimParams.ONSECONDARYACTION, WeaponAnimParams.SECONDARYACTION);
        }

        if (player.CurrentState == PlayerStates.Idle)
        {
            ChangeState(animator, WeaponAnimParams.ONSECONDARYACTION, WeaponAnimParams.IDLE);
        }
        
    }
}
