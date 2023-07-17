using UnityEngine;

public class WeaponSpecialAttackChargeEndState : WeaponState
{
    private float _idleParamModifier = 0.1f;
    private float _moveParamModifier = 1f;

    protected override void OnIdle(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SetAnimParam(animator, _idleParamModifier);
    }

    protected override void OnMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SetAnimParam(animator, _moveParamModifier);

        weapon.PerformMoveInputWhileChargeEnd(input);
    }

    protected override void ExitSpecialAttack(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ChangeNextState(PlayerAnimParameters.SpecialAttack);
    }

    private void SetAnimParam(Animator animator, float modifier)
    {
        Vector2 animParams = player.PlayerFacingDirection.ToVec2() * modifier;

        animator.SetFloat(PlayerAnimParameters.MoveX, animParams.x);
        animator.SetFloat(PlayerAnimParameters.MoveY, animParams.y);

        player.Anim.SetFloat(PlayerAnimParameters.MoveX, animParams.x);
        player.Anim.SetFloat(PlayerAnimParameters.MoveY, animParams.y);
    }
}