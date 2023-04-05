using EnumValue;
using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    #region Roll Variables
    protected Vector2 rollDir = Vector2.down;
    private float checkRollTime;
    private float moveX;
    private float moveY;

    #endregion

    #region ComboAttack Variables
    protected float attackInputDelayTime;
    protected bool comboAttack;

    private float checkAttackTime;
    private float attackCorrectionValue = 0.95f;
    private float attackInputCorrectionValue = 0.4f;

    #endregion

    #region SecondaryAction Variables


    #endregion

    #region Roll State Functions

    protected void LockAttack()
    {
        if (inputHandler.ComboInput)
        {
            inputHandler.UseComboInput();
        }
    }

    protected void CheckRollDuration(AnimatorStateInfo stateInfo)
    {
        checkRollTime += Time.deltaTime;

        if (checkRollTime >= stateInfo.length * 0.9f)
        {
            checkRollTime = 0;
            isAnimationEnded = true;
        }
    }

    protected void SetRollDirection(Animator animator)
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

    #region Player ComboAttack State Funcitons
    protected void CheckAttackTime(AnimatorStateInfo stateInfo)
    {
        checkAttackTime += Time.deltaTime;

        if (checkAttackTime >= stateInfo.length * attackCorrectionValue)
        {
            checkAttackTime = 0;
            isAnimationEnded = true;
        }
    }

    protected void CheckComboAttack()
    {
        if (inputHandler.ComboInput)
        {
            comboAttack = true;
        }
    }

    protected void LockRoll()
    {
        if (inputHandler.RollInput)
        {
            inputHandler.UseRollInput();
        }
    }

    protected void AttackInputDelay(AnimatorStateInfo stateInfo)
    {
        attackInputDelayTime += Time.deltaTime;

        if (attackInputDelayTime <= stateInfo.length * attackInputCorrectionValue)
        {
            if (inputHandler.ComboInput)
            {
                inputHandler.UseComboInput();
            }
        }
    }

    #endregion
}
