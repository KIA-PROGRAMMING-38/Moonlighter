using UnityEngine;

public class PlayerSpecialAttackFinishState : PlayerState
{
    protected override void OnIdle(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 blendTreeParameters = player.PlayerFacingDirection.ToVec2();

        animator.SetVector2(AnimParameters.MoveX, AnimParameters.MoveY, blendTreeParameters);
        player.CurrentWeapon.Anim.SetVector2(AnimParameters.MoveX, AnimParameters.MoveY, blendTreeParameters);
    }
}