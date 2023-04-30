using UnityEngine;

public class BossStickyArmPunchState : BossStickyArmActionState
{
    private SpriteRenderer _sr;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        _sr = target.GetComponent<SpriteRenderer>();
        
        stickyArmPunchAxis = animator.transform.parent.transform;

        lineRenderer = animator.transform.parent.GetComponent<LineRenderer>();
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, stickyArmPunchAxis.position);
        lineRenderer.SetPosition(1, _sr.sprite.bounds.center * stickyArmLength);
        Debug.Break();
        animator.transform.position = target.position.normalized * stickyArmLength;
        angle = Vector2.Angle(Vector2.right, target.position.normalized * stickyArmLength);
    }
}
