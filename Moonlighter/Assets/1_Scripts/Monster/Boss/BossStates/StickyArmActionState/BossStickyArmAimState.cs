using UnityEngine;

public class BossStickyArmAimState : BossStickyArmActionState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stickyArm = animator.transform.GetChild(2).gameObject;
        stickyArmAnimator = stickyArm.transform.GetChild(0).GetComponent<Animator>();
        
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        aimmingTime += Time.deltaTime;

        if (aimmingTime >= 2.0f)
        {
            aimmingTime = 0;
            animator.SetTrigger(MonsterAnimParamsToHash.STICKYARMLAUNCHTRIGGER);
            stickyArmAnimator.SetTrigger(MonsterAnimParamsToHash.STICKYARMPUNCHTRIGGER);
        }
    }
}
