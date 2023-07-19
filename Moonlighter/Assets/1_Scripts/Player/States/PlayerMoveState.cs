using UnityEngine;

public class PlayerMoveState : PlayerState
{
    protected override void OnIdle(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTrigger(PlayerAnimParameters.Idle);
    }

    protected override void OnMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.SetFacingDirection();

        player.Anim.SetVector2(PlayerAnimParameters.MoveX, PlayerAnimParameters.MoveY, input.MoveInput);

        player.Rigid.velocity = input.MoveInput * player.Stat.MoveSpeed;
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