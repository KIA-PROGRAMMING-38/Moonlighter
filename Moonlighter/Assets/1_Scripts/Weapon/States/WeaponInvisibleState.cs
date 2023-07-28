using UnityEngine;

public class WeaponInvisibleState : WeaponState
{
    protected override void OnMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float moveX = player.Anim.GetFloat(AnimParameters.MoveX);
        float moveY = player.Anim.GetFloat(AnimParameters.MoveY);

        animator.SetVector2(AnimParameters.MoveX, AnimParameters.MoveY, moveX, moveY);
    }
}