using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WillWalkBehaviour : StateMachineBehaviour
{
    private WillController _will;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _will = animator.gameObject.GetComponent<WillController>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_will.MoveInput() == Vector2.zero)
        {
            animator.SetBool("Run", false);
        }
        else
        {
            animator.SetFloat("MoveX", _will.AnimMoveX());
            animator.SetFloat("MoveY", _will.AnimMoveY());
            _will.ApplyMovePosition();
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}
