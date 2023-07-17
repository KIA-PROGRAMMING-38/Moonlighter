using UnityEngine;

public class PlayerSpecialAttackFinishState : PlayerState
{
    protected override void OnIdle(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 animParams = player.PlayerFacingDirection.ToVec2();

        animator.SetFloat(PlayerAnimParameters.MoveX, animParams.x);
        animator.SetFloat(PlayerAnimParameters.MoveY, animParams.y);
    }
}