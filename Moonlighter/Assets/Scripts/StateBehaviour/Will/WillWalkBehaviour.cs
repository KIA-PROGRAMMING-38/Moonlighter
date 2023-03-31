using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WillWalkBehaviour : StateMachineBehaviour
{
    private WillController _will;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _will = animator.gameObject.GetComponent<WillController>();
        _will.CurrentState = Will.WillState.WALK;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // 플레이어의 입력이 없으면 IDLE로 변화.
        if (_will.MoveInput() == Vector2.zero)
        {
            SetIdleState(animator);
        }
        else
        {
            Move(animator);
        }

        // 플레이어의 ROLL 입력이 있으면 ROLL로 변화.
        if (_will.RollInput())
        {
            SetRollState(animator);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _will.PrevState = _will.CurrentState;
    }

    void Move(Animator animator)
    {
        animator.SetFloat("MoveX", _will.AnimMoveX());
        animator.SetFloat("MoveY", _will.AnimMoveY());
        _will.ApplyMovePosition();
    }

    void SetIdleState(Animator animator)
    {
        animator.SetBool("Walk", false);
    }

    void SetRollState(Animator animator)
    {
        animator.SetBool("Roll", true);
    }

}
