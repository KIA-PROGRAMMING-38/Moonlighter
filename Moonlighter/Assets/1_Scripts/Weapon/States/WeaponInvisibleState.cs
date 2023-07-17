using UnityEngine;

public class WeaponInvisibleState : WeaponState
{
    protected override void OnMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetFloat(PlayerAnimParameters.MoveX, player.Anim.GetFloat(PlayerAnimParameters.MoveX));
        animator.SetFloat(PlayerAnimParameters.MoveY, player.Anim.GetFloat(PlayerAnimParameters.MoveY));
    }

    protected override void OnNormalAttack(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ChangeNextState(PlayerAnimParameters.NormalAttack);
    }
}