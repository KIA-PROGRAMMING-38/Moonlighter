using UnityEngine;

public class TangleIdleState : MonsterState
{
    protected override void OnMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTrigger(AnimParameters.Move);
    }
}