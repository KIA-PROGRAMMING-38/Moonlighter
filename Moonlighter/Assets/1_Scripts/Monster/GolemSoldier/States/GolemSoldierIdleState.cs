using UnityEngine;

public class GolemSoldierIdleState : MonsterState
{
    protected override void OnMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTrigger(AnimParameters.Move);
    }
}