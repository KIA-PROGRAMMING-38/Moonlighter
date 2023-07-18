using UnityEngine;

public class PlayerIdleState : PlayerState
{
    protected override void OnMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTrigger(AnimParameters.Move);
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
