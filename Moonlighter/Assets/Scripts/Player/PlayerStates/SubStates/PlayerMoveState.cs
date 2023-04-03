using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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

        player.SetVelocity(moveInput * playerData.movementVelocity);

        if (moveInput == Vector2.zero)
        {
            stateMachine.ChangeState(player.IdleState);
        }
        else
        {
            player.Anim.SetFloat("MoveX", moveInput.x);
            player.Anim.SetFloat("MoveY", moveInput.y);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
