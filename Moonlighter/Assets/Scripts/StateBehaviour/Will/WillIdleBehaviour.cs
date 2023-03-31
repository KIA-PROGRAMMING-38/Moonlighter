using UnityEngine;

public class WillIdleBehaviour : StateMachineBehaviour
{
    private WillController _will;

    private bool _isNextActionRolling = false;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _will = animator.gameObject.GetComponent<WillController>();
        _will.CurrentState = Will.WillState.IDLE;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // 행동 체크.
        CheckNextState(animator);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // 다음 행동이 ROLL 이라면 방향을 정해주기.
        if (_isNextActionRolling)
        {
            SetIdleDirection(animator);
        }
        _will.PrevState = _will.CurrentState;
    }

    void CheckNextState(Animator animator)
    {
        if (_will.MoveInput() != Vector2.zero)
        {
            animator.SetBool("Walk", true);
        }

        if (_will.RollInput())
        {
            _isNextActionRolling = true;
            animator.SetBool("Roll", true);
        }
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
