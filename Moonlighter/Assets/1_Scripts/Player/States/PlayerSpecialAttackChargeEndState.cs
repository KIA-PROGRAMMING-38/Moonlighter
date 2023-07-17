using UnityEngine;

public class PlayerSpecialAttackChargeEndState : PlayerState
{
    protected override void OnIdle(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.Rigid.velocity = zeroVelocity;

    }

    protected override void ExitSpecialAttack(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ChangeNextState(PlayerAnimParameters.SpecialAttack);
    }
}