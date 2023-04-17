using UnityEngine;

public class WeaponComboAttackOneState : WeaponAbilityState
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animHandler.IsAnimationEnded && false == inputHandler.WeaponComboInput)
        {
            ChangeState(animator, WeaponAnimParamsToHash.COMBOATTACKONE, WeaponAnimParamsToHash.IDLE);
        }
        else if (animHandler.IsAnimationEnded && inputHandler.WeaponComboInput)
        {
            inputHandler.UseWeaponComboInput();
            ChangeState(animator, WeaponAnimParamsToHash.COMBOATTACKONE, WeaponAnimParamsToHash.COMBOATTACKTWO);
        }
    }
}
