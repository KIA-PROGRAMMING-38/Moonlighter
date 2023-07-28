using UnityEngine;

public class WeaponSpecialAttackChargeEndState : WeaponState
{
    protected override void OnMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.CurrentWeapon.PerformMoveInputOnSpecialAttack(input);
    }

    protected override void ExitSpecialAttack(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTrigger(AnimParameters.SpecialAttack);
    }
}