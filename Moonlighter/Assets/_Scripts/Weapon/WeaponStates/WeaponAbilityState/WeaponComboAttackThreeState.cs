using UnityEngine;

public class WeaponComboAttackThreeState : WeaponAbilityState
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animHandler.IsAnimationEnded)
        {
            inputHandler.UseWeaponComboInput();
            ChangeState(animator, WeaponAnimParamsToHash.COMBOATTACKTHREE, WeaponAnimParamsToHash.IDLE);
        }
    }
}
