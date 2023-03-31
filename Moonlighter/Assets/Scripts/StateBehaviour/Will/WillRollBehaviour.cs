using UnityEngine;

public class WillRollBehaviour : StateMachineBehaviour
{
    private WillController _will;

    public Vector2 _rollDir;

    private float _elapsedTime;
    private float _rollDuration = 0.7f;
    private bool _rollFinish;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _will = animator.gameObject.GetComponent<WillController>();
        _rollFinish = false;

        if (_will.PrevState == Will.WillState.IDLE)
        {
            switch (_will.IdleDir)
            {
                case Will.IdleDirection.DOWN:
                    _rollDir = Vector2.down;
                    break;
                case Will.IdleDirection.UP:
                    _rollDir = Vector2.up;
                    break;
                case Will.IdleDirection.LEFT:
                    _rollDir = Vector2.left;
                    break;
                case Will.IdleDirection.RIGHT:
                    _rollDir = Vector2.right;
                    break;
            }
        }
        else
        {
            _rollDir = new Vector2(animator.GetFloat("MoveX"), animator.GetFloat("MoveY"));
        }

        _will.CurrentState = Will.WillState.ROLL;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _rollDuration)
        {
            _elapsedTime = 0;
            animator.SetBool("Roll", false);
            _will.RollFinish();
            _rollFinish = true;
        }

        if (false == _rollFinish)
        {
            _will.ApplyRollPosition(_rollDir);
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _will.PrevState = _will.CurrentState;
    }
}
