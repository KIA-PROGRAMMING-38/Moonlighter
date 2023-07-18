using UnityEngine;

public class PlayerSpecialAttackFinishState : PlayerState
{
    protected override void OnIdle(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBlendTreeParameter(AnimParameters.MoveX, AnimParameters.MoveY, player.PlayerFacingDirection);
    }
}