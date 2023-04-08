using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumValue;

public class WeaponComboAttackOneState : WeaponAbilityState
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        checkComboAttackOne += Time.deltaTime;

        if (checkComboAttackOne >= stateInfo.length * 0.9f)
        {
            checkComboAttackOne = 0;
            isAnimationEnded = true;
        }

        if (player.CurrentState == PlayerStates.ComboAttackTwo)
        {
            ChangeState(animator, WeaponAnimParams.COMBOATTACKONE, WeaponAnimParams.COMBOATTACKTWO);
        }

        if (isAnimationEnded)
        {
            ChangeState(animator, WeaponAnimParams.COMBOATTACKONE, WeaponAnimParams.IDLE);
        }
    }

}