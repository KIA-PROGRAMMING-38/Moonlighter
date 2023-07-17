using UnityEngine;

public class PlayerSpecialAttackChargingState : PlayerState
{
    protected override void OnSpecialAttack(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ChangeNextState(PlayerAnimParameters.SpecialAttack);
    }
}