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
        if (player.CanAttack)
        {
            ChangeNextState(PlayerAnimParameters.NormalAttack);
        }
    }

    protected override void OnSpecialAttack(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player.CanAttack)
        {
            ChangeNextState(PlayerAnimParameters.SpecialAttack);
        }
    }
}