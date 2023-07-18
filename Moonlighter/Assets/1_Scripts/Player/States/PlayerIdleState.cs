using UnityEngine;

public class PlayerIdleState : PlayerState
{
    protected override void OnMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTrigger(PlayerAnimParameters.Move);
    }

    protected override void OnRoll(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTrigger(PlayerAnimParameters.Roll);
    }

    protected override void OnNormalAttack(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTriggerWithWeapon(player.CurrentWeapon.Anim, PlayerAnimParameters.NormalAttack);
    }

    protected override void OnSpecialAttack(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ChangeNextState(PlayerAnimParameters.SpecialAttack);
    }
}
