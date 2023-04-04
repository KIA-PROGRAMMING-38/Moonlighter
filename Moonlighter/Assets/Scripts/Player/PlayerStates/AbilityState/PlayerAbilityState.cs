using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityState : StateMachineBehaviour
{
    protected PlayerInputHandler inputHandler;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        inputHandler = animator.gameObject.GetComponent<PlayerInputHandler>();
    }
}
