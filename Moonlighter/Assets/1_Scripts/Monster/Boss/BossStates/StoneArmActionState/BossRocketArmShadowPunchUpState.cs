using UnityEngine;

public class BossRocketArmShadowPunchUpState : BossRocketArmState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ++punchCount;
        rocketArmBody = animator.transform.GetChild(0).gameObject;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rocketArmBody.SetActive(false);
        if (punchCount == 4)
        {
            punchCount = 0;
            animator.gameObject.SetActive(false);
        }
    }
}
