using EnumValue;
using UnityEngine;

public class WeaponComboAttackTwoState : WeaponAbilityState
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animHandler.IsAnimationEnded && false == inputHandler.WeaponComboInput)
        {
            ChangeState(animator, WeaponAnimParams.COMBOATTACKTWO, WeaponAnimParams.IDLE);
        }
        if (animHandler.IsAnimationEnded && inputHandler.WeaponComboInput)
        {
            ChangeState(animator, WeaponAnimParams.COMBOATTACKTWO, WeaponAnimParams.COMBOATTACKTHREE);
        }
    }
}
