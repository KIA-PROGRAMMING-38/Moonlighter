using UnityEngine;

public class WeaponSpecialAttackChargeEndState : WeaponState
{
    private float _idleParamModifier = 0.1f;

    protected override void OnIdle(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBlendTreeParameter(AnimParameters.MoveX, AnimParameters.MoveY, player.PlayerFacingDirection, _idleParamModifier);
    }

    protected override void OnMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBlendTreeParameter(AnimParameters.MoveX, AnimParameters.MoveY, player.PlayerFacingDirection);

        player.CurrentWeapon.PerformMoveInputOnSpecialAttack(input);
    }

    protected override void ExitSpecialAttack(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTrigger(AnimParameters.SpecialAttack);
    }
}