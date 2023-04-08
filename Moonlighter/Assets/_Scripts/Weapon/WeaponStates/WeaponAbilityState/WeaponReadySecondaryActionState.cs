using EnumValue;
using UnityEngine;

public class WeaponReadySecondaryActionState : WeaponAbilityState
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CheckSecondaryDuration(stateInfo);

        if (player.CurrentState == PlayerStates.Idle)
        {
            ChangeState(animator, WeaponAnimParams.READYSECONDARYACTION, WeaponAnimParams.IDLE);
        }

        if (isAnimationEnded && player.CurrentState == PlayerStates.OnSecondaryAction)
        {
            isAnimationEnded = false;
            ChangeState(animator, WeaponAnimParams.READYSECONDARYACTION, WeaponAnimParams.ONSECONDARYACTION);
        }
    }
}
