using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.SetVelocity(moveInput * playerData.MovementVelocity);

        if (false == rollInput && moveInput == Vector2.zero)
        {
            stateMachine.ChangeState(player.IdleState);
        }
        else if(false == rollInput && moveInput != Vector2.zero && false == comboInput)
        {
            player.Anim.SetFloat("MoveX", moveInput.x);
            player.Anim.SetFloat("MoveY", moveInput.y);
        }
        else if(false == rollInput && moveInput != Vector2.zero && comboInput)
        {
            player.InputHandler.UseComboInput();
            stateMachine.ChangeState(player.ComboAttackOne);
        }
        else if (rollInput)
        {
            player.InputHandler.UseRollInput();
            stateMachine.ChangeState(player.RollState);
        }
    }

}
