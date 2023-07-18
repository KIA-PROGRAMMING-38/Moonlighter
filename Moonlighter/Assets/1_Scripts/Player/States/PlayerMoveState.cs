using UnityEngine;

public class PlayerMoveState : PlayerState
{
    protected override void OnIdle(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTrigger(AnimParameters.Idle);
    }

    protected override void OnMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.SetFacingDirection();

        player.Anim.SetMovementParameters(AnimParameters.MoveX, AnimParameters.MoveY, input.MoveInput);

        player.Rigid.velocity = input.MoveInput * player.Stat.MoveSpeed;
    }

    protected override void OnRoll(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTrigger(AnimParameters.Roll);
    }

    protected override void OnNormalAttack(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTriggerWithWeapon(player.CurrentWeapon.Anim, AnimParameters.NormalAttack);
    }

    protected override void OnSpecialAttack(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTriggerWithWeapon(player.CurrentWeapon.Anim, AnimParameters.SpecialAttack);
    }
}