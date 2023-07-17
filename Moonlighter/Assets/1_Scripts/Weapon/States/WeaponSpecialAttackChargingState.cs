using UnityEngine;

public class WeaponSpecialAttackChargingState : WeaponState
{
    protected override void OnMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        weapon.PerformMoveInputWhileCharging(input);
    }

    protected override void OnSpecialAttack(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ChangeNextState(PlayerAnimParameters.SpecialAttack);
    }
}