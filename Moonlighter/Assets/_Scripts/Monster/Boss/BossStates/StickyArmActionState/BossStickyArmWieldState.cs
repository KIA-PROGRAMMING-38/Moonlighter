using UnityEngine;

public class BossStickyArmWieldState : BossStickyArmActionState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stickyArm = animator.transform.GetChild(2).gameObject;
        lineRenderer = stickyArm.GetComponent<LineRenderer>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        wieldingTime += Time.deltaTime;

        if (wieldingTime > 3.0f)
        {
            wieldingTime = 0;
            animator.SetTrigger(MonsterAnimParamsToHash.STICKYARMWIELDENDTRIGGER);
        }
    }


    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        lineRenderer.enabled = false;
        stickyArm.SetActive(false);
    }
}
