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
        else if(false == rollInput && moveInput != Vector2.zero)
        {
            player.Anim.SetFloat("MoveX", moveInput.x);
            player.Anim.SetFloat("MoveY", moveInput.y);
        }
        else if (rollInput)
        {
            player.InputHandler.UseRollInput();
            stateMachine.ChangeState(player.RollState);
        }
    }

}
