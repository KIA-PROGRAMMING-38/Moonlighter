using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    protected Vector2 rollDir = Vector2.down;
    protected float checkRollTime;
    protected float moveX;
    protected float moveY;

    protected float checkAttackTime;
    protected float attackCorrectionValue = 0.95f;
    protected bool comboAttack;


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

    #endregion
}
