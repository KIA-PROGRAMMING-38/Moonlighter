using UnityEngine;

public class EffectState : StateMachineBehaviour
{
    protected EffectController effectController;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        effectController = animator.GetComponent<EffectController>();
        Debug.Assert(effectController is not null);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (IsStateEnd(stateInfo))
        {
            Managers.Effect.ReleaseToPool(effectController);
            animator.gameObject.SetActive(false);
        }

        static bool IsStateEnd(AnimatorStateInfo stateInfo) => stateInfo.normalizedTime >= 1;
    }
}