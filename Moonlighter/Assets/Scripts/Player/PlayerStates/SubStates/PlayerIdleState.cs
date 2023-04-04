using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(Vector2.zero);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (false == player.InputHandler.RollInput && moveInput != Vector2.zero)
        {
            stateMachine.ChangeState(player.MoveState);
        }
        else if (player.InputHandler.RollInput)
        {
            player.InputHandler.UseRollInput();
            stateMachine.ChangeState(player.RollState);
        }
    }
}
