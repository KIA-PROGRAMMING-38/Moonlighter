using EnumValue;
using UnityEngine;

public class WeaponComboAttackOneState : WeaponAbilityState
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CheckAttackTime(stateInfo);

        if (isAnimationEnded && player.CurrentState == PlayerStates.Idle)
        {
            ChangeState(animator, WeaponAnimParams.COMBOATTACKONE, WeaponAnimParams.IDLE);
        }
        else if (isAnimationEnded && player.CurrentState == PlayerStates.ComboAttackTwo)
        {
            ChangeState(animator, WeaponAnimParams.COMBOATTACKONE, WeaponAnimParams.COMBOATTACKTWO);
        }
    }
}
