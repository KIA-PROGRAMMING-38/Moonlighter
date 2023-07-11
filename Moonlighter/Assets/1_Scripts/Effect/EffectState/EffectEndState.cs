using UnityEngine;

public class EffectEndState : EffectState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        Managers.Effect.ReleaseToPool(effectController);

        animator.gameObject.SetActive(false);
    }
}