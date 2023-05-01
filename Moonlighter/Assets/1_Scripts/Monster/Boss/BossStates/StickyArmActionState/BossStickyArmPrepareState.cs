using UnityEngine;

public class BossStickyArmPrepareState : BossStickyArmActionState
{
    public GameObject StickyArm;
    public GameObject StickyArmPunch;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        StickyArm = animator.transform.GetChild(7).gameObject;
        StickyArmPunch = StickyArm.transform.GetChild(1).gameObject;
        RaycastHit2D pos = Physics2D.Raycast(StickyArm.transform.position, target.transform.position - StickyArm.transform.position);
        StickyArmPunch.transform.position = pos.point;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        StickyArm.SetActive(true);
        
    }
}
