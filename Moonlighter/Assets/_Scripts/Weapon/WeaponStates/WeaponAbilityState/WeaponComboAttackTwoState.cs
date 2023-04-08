using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponComboAttackTwoState : WeaponAbilityState
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        checkComboAttackOne += Time.deltaTime;

        if (checkComboAttackOne >= stateInfo.length * 0.9f)
        {
            checkComboAttackOne = 0;
            isAnimationEnded = true;
        }

        if (isAnimationEnded)
        {
            ChangeState(animator, WeaponAnimParams.COMBOATTACKTWO, WeaponAnimParams.IDLE);
        }
    }
}
