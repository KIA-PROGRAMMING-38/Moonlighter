using UnityEngine;
using EnumValue;

public class PlayerRollState : PlayerAbilityState
{
    private float _checkRollTime;
    private float _moveX;
    private float _moveY;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        player.CurrentState = PlayerStates.Roll;

        SetRollDirection(animator);

        rigid.velocity = rollDir * playerData.RollingVelocity;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        CheckRollDuration(stateInfo);

        if (isAnimationEnded)
        {
            ChangeState(animator, PlayerStates.Roll, PlayerAnimParams.ROLL, PlayerAnimParams.IDLE);
        }
    }

    #region Roll State Functions
    private void CheckRollDuration(AnimatorStateInfo stateInfo)
    {
        _checkRollTime += Time.deltaTime;

        if (_checkRollTime >= stateInfo.length * 0.9f)
        {
            _checkRollTime = 0;
            isAnimationEnded = true;
        }
    }

    private void SetRollDirection(Animator animator)
    {
        _moveX = animator.GetFloat(PlayerAnimParams.MOVEX);
        _moveY = animator.GetFloat(PlayerAnimParams.MOVEY);

        if (player.PrevState == PlayerStates.Idle)
        {
            if (_moveX != 0 && _moveY > 0)
            {
                rollDir = Vector2.up;
            }
            else if (_moveX != 0 && _moveY < 0)
            {
                rollDir = Vector2.down;
            }
            else if (_moveX == 0 && _moveY == 1)
            {
                rollDir = Vector2.up;
            }
            else if (_moveX == 0 && _moveY == -1)
            {
                rollDir = Vector2.down;
            }
            else if (_moveX == 1 && _moveY == 0)
            {
                rollDir = Vector2.right;
            }
            else if (_moveX == -1 && _moveY == 0)
            {
                rollDir = Vector2.left;
            }
        }
        else if (player.PrevState == PlayerStates.Move)
        {
            rollDir = new Vector2(_moveX, _moveY);
        }
    }

    #endregion
}
