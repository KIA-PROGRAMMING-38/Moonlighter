using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAbilityState : WeaponState
{
    protected float checkComboAttackOne;
    protected float attackCorrectionValue = 0.95f;

    protected void CheckAttackTime(AnimatorStateInfo stateInfo)
    {
        checkComboAttackOne += Time.fixedDeltaTime;

        if (checkComboAttackOne >= stateInfo.length * attackCorrectionValue)
        {
            checkComboAttackOne = 0;
            isAnimationEnded = true;
        }
    }

}
