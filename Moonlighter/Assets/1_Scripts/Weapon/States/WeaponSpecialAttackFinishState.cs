using UnityEngine;

public class WeaponSpecialAttackFinishState : WeaponState
{
    private float _idleParamModifier = 1;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        weapon.PerformWhileSpecialAttackFinish();
    }

    protected override void OnIdle(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SetAnimParam(animator, _idleParamModifier);
    }

    private void SetAnimParam(Animator animator, float modifier)
    {
        Vector2 animParams = player.PlayerFacingDirection.ToVec2() * modifier;

        animator.SetFloat(PlayerAnimParameters.MoveX, animParams.x);
        animator.SetFloat(PlayerAnimParameters.MoveY, animParams.y);
    }
}