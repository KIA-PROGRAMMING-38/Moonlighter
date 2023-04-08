using UnityEngine;

public class WeaponAbilityState : WeaponState
{
    protected float checkComboAttack;
    protected float attackCorrectionValue = 0.95f;

    protected float checkSecondaryDuration;

    protected void CheckAttackTime(AnimatorStateInfo stateInfo)
    {
        checkComboAttack += Time.deltaTime;

        if (checkComboAttack >= stateInfo.length * attackCorrectionValue)
        {
            checkComboAttack = 0;
            isAnimationEnded = true;
        }
    }

    protected void CheckSecondaryDuration(AnimatorStateInfo stateInfo)
    {
        checkSecondaryDuration += Time.deltaTime;
        if (checkSecondaryDuration >= stateInfo.length * attackCorrectionValue)
        {
            checkSecondaryDuration = 0;
            isAnimationEnded = true;
        }
    }

}
