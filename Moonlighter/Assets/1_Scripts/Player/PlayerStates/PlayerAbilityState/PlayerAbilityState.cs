using EnumValue;
using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    #region Roll Variables
    protected Vector2 rollDir = Vector2.down;
    private float moveX;
    private float moveY;

    #endregion

    #region ComboAttack Variables
    
    protected Vector2 moveAttackDir = Vector2.zero;

    #endregion

    #region Roll State Functions

    protected void LockAttack()
    {
        if (inputHandler.ComboInput)
        {
            inputHandler.UseComboInput();
        }

        if (inputHandler.WeaponComboInput)
        {
            inputHandler.UseWeaponComboInput();
        }
    }

    protected void SetRollDirection(Animator animator)
    {
        moveX = animator.GetFloat(PlayerAnimParamsToHash.MOVEX);
        moveY = animator.GetFloat(PlayerAnimParamsToHash.MOVEY);

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

    protected void LockRoll()
    {
        if (inputHandler.RollInput)
        {
            inputHandler.UseRollInput();
        }
    }

    protected void SetMoveAttackDirection()
    {
        if (inputHandler.MoveInput != Vector2.zero)
        {
            moveAttackDir = Vector2.zero;

            float moveX = inputHandler.MoveInput.x;
            float moveY = inputHandler.MoveInput.y;

            if (moveX != 0 && moveY > 0)
            {
                moveAttackDir = Vector2.up;
            }
            else if (moveX != 0 && moveY < 0)
            {
                moveAttackDir = Vector2.down;
            }
            else if (moveX == 0 && moveY == 1)
            {
                moveAttackDir = Vector2.up;
            }
            else if (moveX == 0 && moveY == -1)
            {
                moveAttackDir = Vector2.down;
            }
            else if (moveX == 1 && moveY == 0)
            {
                moveAttackDir = Vector2.right;
            }
            else if (moveX == -1 && moveY == 0)
            {
                moveAttackDir = Vector2.left;
            }
            rigid.MovePosition((Vector2)rigid.transform.position + moveAttackDir * 0.08f);
        }
    }

    #endregion

}
