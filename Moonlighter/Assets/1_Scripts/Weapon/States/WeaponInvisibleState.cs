using UnityEngine;

public class WeaponInvisibleState : WeaponState
{
    protected override void OnMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetMovementParametersFromSource(player.Anim, PlayerAnimParameters.MoveX, PlayerAnimParameters.MoveY);
    }

    protected override void OnSpecialAttack(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player.CanAttack)
        {
            ChangeNextState(PlayerAnimParameters.SpecialAttack);
        }
    }
}