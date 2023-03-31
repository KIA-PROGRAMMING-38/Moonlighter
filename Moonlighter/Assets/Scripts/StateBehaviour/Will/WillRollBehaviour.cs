using UnityEngine;

public class WillRollBehaviour : StateMachineBehaviour
{
    private WillController _will;

    public Vector2 _rollDir;

    private float _elapsedTime;
    private float _rollDuration = 0.51f;
    private bool _rollFinish;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _will = animator.gameObject.GetComponent<WillController>();
        _rollFinish = false;

        // 구를 방향 정해주기.
        SetRollingDirection(animator);

        _will.CurrentState = Will.WillState.ROLL;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // 구르기 시간 체크.
        CheckRollingDuration(animator);

        // 구르는 중이라면 구르는 이동.
        Rolling();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _will.PrevState = _will.CurrentState;
    }

    void SetRollingDirection(Animator animator)
    {
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
    }

    void CheckRollingDuration(Animator animator)
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _rollDuration)
        {
            _elapsedTime = 0;
            animator.SetBool("Roll", false);
            _will.RollFinish();
            _rollFinish = true;
        }
    }

    void Rolling()
    {
        if (false == _rollFinish)
        {
            _will.ApplyRollPosition(_rollDir);
        }
    }
}
