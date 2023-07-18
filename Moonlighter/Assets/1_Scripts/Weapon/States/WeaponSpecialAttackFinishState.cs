using UnityEngine;

public class WeaponSpecialAttackFinishState : WeaponState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        player.CurrentWeapon.PerformWhileSpecialAttackFinish();
    }

    protected override void OnIdle(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBlendTreeParameter(AnimParameters.MoveX, AnimParameters.MoveY, player.PlayerFacingDirection);
    }
}