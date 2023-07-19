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
        animator.SetTrigger(PlayerAnimParameters.NormalAttack);
        player.CurrentWeapon.Anim.SetTrigger(PlayerAnimParameters.NormalAttack);
    }
}
