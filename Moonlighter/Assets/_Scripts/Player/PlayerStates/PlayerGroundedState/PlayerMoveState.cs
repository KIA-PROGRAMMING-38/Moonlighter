using UnityEngine;
using EnumValue;

public class PlayerMoveState : PlayerGroundedState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        player.CurrentState = PlayerStates.Move;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        if (inputHandler.SecondaryActionInput)
        {
            ChangeState(animator, PlayerStates.Move, PlayerAnimParams.MOVE, PlayerAnimParams.READYSECONDARYACTION);
        }
        
        if (false == inputHandler.RollInput && inputHandler.MoveInput != Vector2.zero && false == inputHandler.ComboInput)
        {
            SetMoveVelocity(animator);
        }
        else if (inputHandler.MoveInput == Vector2.zero)
        {
            ChangeState(animator, PlayerStates.Move, PlayerAnimParams.MOVE, PlayerAnimParams.IDLE);
        }
        else if (inputHandler.RollInput && inputHandler.MoveInput != Vector2.zero)
        {
            inputHandler.UseRollInput();
            ChangeState(animator, PlayerStates.Move, PlayerAnimParams.MOVE, PlayerAnimParams.ROLL);
        }
        else if (false == inputHandler.RollInput && inputHandler.ComboInput && inputHandler.MoveInput != Vector2.zero)
        {
            inputHandler.UseComboInput();
            ChangeState(animator, PlayerStates.Move, PlayerAnimParams.MOVE, PlayerAnimParams.COMBOATTACKONE);
        }
        
    }

    #region Move State Functions
    private void SetMoveVelocity(Animator animator)
    {
        animator.SetFloat(PlayerAnimParams.MOVEX, inputHandler.MoveInput.x);
        animator.SetFloat(PlayerAnimParams.MOVEY, inputHandler.MoveInput.y);
        rigid.velocity = inputHandler.MoveInput * playerData.MovementVelocity;
    }

    #endregion
}
