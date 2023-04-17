using UnityEngine;

public class BossIdleActionState : BossState
{
    protected GameObject wave;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        wave = animator.gameObject.transform.GetChild(5).gameObject;
    }
}
