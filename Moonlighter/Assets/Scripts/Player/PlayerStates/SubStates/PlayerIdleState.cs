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

        if (false == rollInput && moveInput != Vector2.zero)
        {
            stateMachine.ChangeState(player.MoveState);
        }
        else if (false == rollInput && comboInput)
        {
            player.InputHandler.UseComboInput();
            stateMachine.ChangeState(player.ComboAttackOne);
        }
        else if (rollInput && false == comboInput)
        {
            player.InputHandler.UseRollInput();
            stateMachine.ChangeState(player.RollState);
        }
    }
}
