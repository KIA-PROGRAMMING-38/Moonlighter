using UnityEngine;

public class BossRockDownEndState : BossRockState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
         upPoint = animator.transform.position + Vector3.up;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.Lerp(animator.transform.position, upPoint, 5f * Time.deltaTime);
    }
}
