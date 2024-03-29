using UnityEngine;

public class WeaponNormalAttackState : WeaponState
{
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

        animator.SetTrigger(AnimParameters.NormalAttack);
    }
}