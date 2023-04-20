using UnityEngine;

public class BossStickyArmPunchAimState : BossStickyArmActionState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        stickyArmPunchAxis = animator.transform.parent.transform;
        stickyArmPunchOriginPos = animator.transform.parent.GetChild(1);
        animator.transform.position = stickyArmPunchOriginPos.position;
        lineRenderer = animator.transform.parent.GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        float diff = Vector2.SignedAngle((animator.transform.position - stickyArmPunchAxis.position).normalized, (target.position - stickyArmPunchAxis.position).normalized);

        Quaternion end = stickyArmPunchAxis.rotation * Quaternion.Euler(0f, 0f, diff);

        stickyArmPunchAxis.rotation = Quaternion.Lerp(stickyArmPunchAxis.rotation, end, 10f * Time.deltaTime);
    }
}
