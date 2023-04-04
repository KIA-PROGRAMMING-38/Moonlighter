using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected Vector2 moveInput;

    protected bool rollInput;
    protected bool comboInput;

    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        moveInput = player.InputHandler.MoveInput;
        rollInput = player.InputHandler.RollInput;
        comboInput = player.InputHandler.ComboInput;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
