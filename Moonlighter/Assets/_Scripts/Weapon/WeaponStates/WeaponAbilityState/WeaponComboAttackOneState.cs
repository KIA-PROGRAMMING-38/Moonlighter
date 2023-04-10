using UnityEngine;

public class WeaponComboAttackOneState : WeaponAbilityState
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animHandler.IsAnimationEnded && false == inputHandler.WeaponComboInput)
        {
            ChangeState(animator, WeaponAnimParams.COMBOATTACKONE, WeaponAnimParams.IDLE);
        }
        else if (animHandler.IsAnimationEnded && inputHandler.WeaponComboInput)
        {
            inputHandler.UseWeaponComboInput();
            ChangeState(animator, WeaponAnimParams.COMBOATTACKONE, WeaponAnimParams.COMBOATTACKTWO);
        }
    }
}
