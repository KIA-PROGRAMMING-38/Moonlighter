using UnityEngine;

public class EffectState : StateMachineBehaviour
{
    protected EffectController effectController;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        effectController = animator.GetComponent<EffectController>();

        Debug.Assert(effectController is not null);
    }
}