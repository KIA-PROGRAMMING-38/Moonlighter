using UnityEngine;
using EnumValue;

public class PlayerRollState : PlayerAbilityState
{
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

        LockAttack();
        
        if (isAnimationEnded)
        {
            ChangeState(animator, PlayerStates.Roll, PlayerAnimParams.ROLL, PlayerAnimParams.IDLE);
        }
    }

    #region Roll State Functions

    private void LockAttack()
    {
        if (inputHandler.ComboInput)
        {
            inputHandler.UseComboInput();
        }
    }

    private void CheckRollDuration(AnimatorStateInfo stateInfo)
    {
        checkRollTime += Time.deltaTime;

        if (checkRollTime >= stateInfo.length * 0.9f)
        {
            checkRollTime = 0;
            isAnimationEnded = true;
        }
    }

    private void SetRollDirection(Animator animator)
    {
        moveX = animator.GetFloat(PlayerAnimParams.MOVEX);
        moveY = animator.GetFloat(PlayerAnimParams.MOVEY);

        if (player.PrevState == PlayerStates.Idle)
        {
            if (moveX != 0 && moveY > 0)
            {
                rollDir = Vector2.up;
            }
            else if (moveX != 0 && moveY < 0)
            {
                rollDir = Vector2.down;
            }
            else if (moveX == 0 && moveY == 1)
            {
                rollDir = Vector2.up;
            }
            else if (moveX == 0 && moveY == -1)
            {
                rollDir = Vector2.down;
            }
            else if (moveX == 1 && moveY == 0)
            {
                rollDir = Vector2.right;
            }
            else if (moveX == -1 && moveY == 0)
            {
                rollDir = Vector2.left;
            }
        }
        else if (player.PrevState == PlayerStates.Move)
        {
            rollDir = new Vector2(moveX, moveY);
        }
    }

    #endregion
}
