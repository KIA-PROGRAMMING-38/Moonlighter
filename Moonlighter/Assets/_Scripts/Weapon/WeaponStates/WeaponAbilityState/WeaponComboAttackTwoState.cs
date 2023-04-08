using EnumValue;
using UnityEngine;

public class WeaponComboAttackTwoState : WeaponAbilityState
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CheckAttackTime(stateInfo);

        if (isAnimationEnded && player.CurrentState == PlayerStates.Idle)
        {
            ChangeState(animator, WeaponAnimParams.COMBOATTACKTWO, WeaponAnimParams.IDLE);
        }
        if (isAnimationEnded && player.CurrentState == PlayerStates.ComboAttackThree)
        {
            ChangeState(animator, WeaponAnimParams.COMBOATTACKTWO, WeaponAnimParams.COMBOATTACKTHREE);
        }
    }
}
