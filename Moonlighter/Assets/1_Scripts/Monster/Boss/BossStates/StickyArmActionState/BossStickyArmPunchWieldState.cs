using UnityEngine;

public class BossStickyArmPunchWieldState : BossStickyArmActionState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        stickyArmPunchAxis = animator.transform.parent.transform;

        lineRenderer = animator.transform.parent.GetComponent<LineRenderer>();
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, stickyArmPunchAxis.position);
        lineRenderer.SetPosition(1, target.position.normalized * stickyArmLength);
        animator.transform.position = target.position.normalized * stickyArmLength;
    }
}
