using UnityEngine;

public class WeaponNormalAttackState : WeaponState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        if (input.IsMoving)
        {
            animator.SetFloat(PlayerAnimParameters.MoveX, player.Anim.GetFloat(PlayerAnimParameters.MoveX));
            animator.SetFloat(PlayerAnimParameters.MoveY, player.Anim.GetFloat(PlayerAnimParameters.MoveY));
        }
    }

    [SerializeField][Range(0, 0.5f)] private float _attackableMinTime = 0.3f;
    [SerializeField][Range(0.5f, 1f)] private float _attackableMaxTime = 0.7f;
    protected override void OnNormalAttack(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime < _attackableMinTime)
        {
            return;
        }

        if (stateInfo.normalizedTime > _attackableMaxTime)
        {
            return;
        }

        ChangeNextState(PlayerAnimParameters.NormalAttack);
    }
}