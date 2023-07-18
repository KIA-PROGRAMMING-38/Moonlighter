using UnityEngine;

public class WeaponSpecialAttackChargingState : WeaponState
{
    protected override void OnMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.CurrentWeapon.PerformMoveInputOnSpecialAttack(input);
    }

    protected override void OnSpecialAttack(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTrigger(AnimParameters.SpecialAttack);
    }
}