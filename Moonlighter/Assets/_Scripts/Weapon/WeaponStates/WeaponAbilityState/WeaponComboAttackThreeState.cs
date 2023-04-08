using UnityEngine;

public class WeaponComboAttackThreeState : WeaponAbilityState
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CheckAttackTime(stateInfo);

        if (isAnimationEnded)
        {
            ChangeState(animator, WeaponAnimParams.COMBOATTACKTHREE, WeaponAnimParams.IDLE);
        }
    }
}
