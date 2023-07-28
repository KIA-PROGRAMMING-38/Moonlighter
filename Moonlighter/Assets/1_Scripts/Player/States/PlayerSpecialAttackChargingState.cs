using UnityEngine;

public class PlayerSpecialAttackChargingState : PlayerState
{
    protected override void OnSpecialAttack(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTrigger(AnimParameters.SpecialAttack);
    }
}