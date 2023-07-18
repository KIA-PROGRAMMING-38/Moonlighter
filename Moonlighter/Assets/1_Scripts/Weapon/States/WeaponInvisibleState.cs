using UnityEngine;

public class WeaponInvisibleState : WeaponState
{
    protected override void OnMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetMovementParametersFromSource(player.Anim, AnimParameters.MoveX, AnimParameters.MoveY);
    }
}