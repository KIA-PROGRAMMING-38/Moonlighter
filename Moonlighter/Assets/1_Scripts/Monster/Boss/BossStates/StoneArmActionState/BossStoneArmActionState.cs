using UnityEngine;

public class BossStoneArmActionState : BossState
{
    protected GameObject rocketArm;
    protected Transform rocketArmShadow;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        rocketArm = animator.gameObject.transform.root.GetChild(6).gameObject;
    }
}
