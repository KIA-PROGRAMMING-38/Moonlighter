using UnityEngine;

public class BossStoneArmNoArmIdleState : BossStoneArmActionState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        rocketArmShadow = rocketArm.transform.GetChild(0).gameObject.transform;

        rocketArmShadow.gameObject.SetActive(true);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (false == rocketArmShadow.gameObject.activeSelf)
        {
            animator.SetTrigger(MonsterAnimParams.STONEARMPUNCHFINISHTRIGGER);
        }
    }
}
