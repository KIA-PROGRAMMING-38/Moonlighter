using UnityEngine;

public class BossStickyArmPrepareState : BossStickyArmActionState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stickyArm = animator.transform.GetChild(2).gameObject;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stickyArm.SetActive(true);   
    }
}
