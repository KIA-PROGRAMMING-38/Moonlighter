using UnityEngine;

public class BossState : StateMachineBehaviour
{
    protected Boss boss;
    protected Transform target;
    protected BossAnimationHandler animHandler;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = GameObject.Find("Player").transform;
        animHandler = animator.transform.root.GetComponent<BossAnimationHandler>();
        animHandler.ResetAnimationState();
        boss = animator.gameObject.GetComponent<Boss>();
    }

}
