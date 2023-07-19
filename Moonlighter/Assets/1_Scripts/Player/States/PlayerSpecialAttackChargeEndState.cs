using UnityEngine;

public class PlayerSpecialAttackChargeEndState : PlayerState
{
    private float _idleParamModifier = 0.1f;

    protected override void OnIdle(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.Rigid.velocity = zeroVelocity;

        Vector2 blendTreeParameters = player.PlayerFacingDirection.ToVec2() * _idleParamModifier;

        animator.SetVector2(AnimParameters.MoveX, AnimParameters.MoveY, blendTreeParameters);
        player.CurrentWeapon.Anim.SetVector2(AnimParameters.MoveX, AnimParameters.MoveY, blendTreeParameters);
    }

    protected override void OnMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 blendTreeParameters = player.PlayerFacingDirection.ToVec2();

        animator.SetVector2(AnimParameters.MoveX, AnimParameters.MoveY, blendTreeParameters);
        player.CurrentWeapon.Anim.SetVector2(AnimParameters.MoveX, AnimParameters.MoveY, blendTreeParameters);
    }

    protected override void ExitSpecialAttack(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTrigger(AnimParameters.SpecialAttack);
    }
}