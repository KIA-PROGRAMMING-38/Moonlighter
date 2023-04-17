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
            ChangeState(animator, PlayerStates.Move, PlayerAnimParamsToHash.MOVE, PlayerAnimParamsToHash.READYSECONDARYACTION);
        }
        
        if (false == inputHandler.RollInput && inputHandler.MoveInput != Vector2.zero && false == inputHandler.ComboInput)
        {
            SetMoveVelocity(animator);
        }
        else if (inputHandler.MoveInput == Vector2.zero)
        {
            ChangeState(animator, PlayerStates.Move, PlayerAnimParamsToHash.MOVE, PlayerAnimParamsToHash.IDLE);
        }
        else if (inputHandler.RollInput && inputHandler.MoveInput != Vector2.zero)
        {
            inputHandler.UseRollInput();
            ChangeState(animator, PlayerStates.Move, PlayerAnimParamsToHash.MOVE, PlayerAnimParamsToHash.ROLL);
        }
        else if (false == inputHandler.RollInput && inputHandler.ComboInput && inputHandler.MoveInput != Vector2.zero)
        {
            inputHandler.UseComboInput();
            ChangeState(animator, PlayerStates.Move, PlayerAnimParamsToHash.MOVE, PlayerAnimParamsToHash.COMBOATTACKONE);
        }
        
    }

    #region Move State Functions
    private void SetMoveVelocity(Animator animator)
    {
        animator.SetFloat(PlayerAnimParamsToHash.MOVEX, inputHandler.MoveInput.x);
        animator.SetFloat(PlayerAnimParamsToHash.MOVEY, inputHandler.MoveInput.y);
        rigid.velocity = inputHandler.MoveInput * playerData.MovementVelocity;
    }

    #endregion
}
