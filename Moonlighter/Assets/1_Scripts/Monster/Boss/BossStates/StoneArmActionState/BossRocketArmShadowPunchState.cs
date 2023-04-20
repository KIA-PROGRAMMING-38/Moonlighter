using UnityEngine;

public class BossRocketArmShadowPunchState : BossRocketArmState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        rocketArmBody = animator.transform.GetChild(0).gameObject;
        rocketArmBody.SetActive(true);
    }

}
