using UnityEngine;

public class WeaponInvisibleState : WeaponState
{
    protected override void OnMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float moveX = player.Anim.GetFloat(PlayerAnimParameters.MoveX);
        float moveY = player.Anim.GetFloat(PlayerAnimParameters.MoveY);

        animator.SetVector2(PlayerAnimParameters.MoveX, PlayerAnimParameters.MoveY, moveX, moveY);
    }
}