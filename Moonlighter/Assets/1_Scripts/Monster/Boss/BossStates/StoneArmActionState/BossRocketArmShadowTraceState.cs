using UnityEngine;

public class BossRocketArmShadowTraceState : BossRocketArmState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        animator.transform.position = target.position;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 dir = target.position - animator.transform.position;

        animator.transform.Translate(dir * (Time.deltaTime * shadowMoveSpeed));
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        RocketArmShadow.AttackPoint = animator.transform;
    }
}
