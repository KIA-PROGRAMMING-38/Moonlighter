using UnityEngine;

public class BossRockDownState : BossRockState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        downPoint = animator.transform.parent.transform;
        boss = animator.transform.root.GetComponent<Boss>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.Lerp(animator.transform.position, downPoint.position, 5f * Time.deltaTime);
        if (boss.RockStateEnd)
        {
            animator.SetTrigger(MonsterAnimParamsToHash.ROCKSTATEENDTRIGGER);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.RockStateEnd = false;
    }
}
