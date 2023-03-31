using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class WillIdleBehaviour : StateMachineBehaviour
{
    private WillController _will;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _will = animator.gameObject.GetComponent<WillController>();
        _will.CurrentState = Will.WillState.IDLE;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_will.MoveInput() != Vector2.zero)
        {
            animator.SetBool("Walk", true);
        }

        if (_will.RollInput())
        {
            animator.SetBool("Roll", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SetIdleDirection(animator);
        _will.PrevState = _will.CurrentState;
    }

    void SetIdleDirection(Animator animator)
    {
        if (animator.GetFloat("MoveX") == 1 && animator.GetFloat("MoveY") == 0)
        {
            _will.IdleDir = Will.IdleDirection.RIGHT;
        }
        else if (animator.GetFloat("MoveX") == -1 && animator.GetFloat("MoveY") == 0)
        {
            _will.IdleDir = Will.IdleDirection.LEFT;
        }
        else if (animator.GetFloat("MoveX") == 0 && animator.GetFloat("MoveY") == 1)
        {
            _will.IdleDir = Will.IdleDirection.UP;
        }
        else if (animator.GetFloat("MoveX") == 0 && animator.GetFloat("MoveY") == -1)
        {
            _will.IdleDir = Will.IdleDirection.DOWN;
        }
        else if (animator.GetFloat("MoveX") != 0 && animator.GetFloat("MoveY") > 0)
        {
            _will.IdleDir = Will.IdleDirection.UP;
        }
        else if (animator.GetFloat("MoveX") != 0 && animator.GetFloat("MoveY") < 0)
        {
            _will.IdleDir = Will.IdleDirection.DOWN;
        }
    }
}
