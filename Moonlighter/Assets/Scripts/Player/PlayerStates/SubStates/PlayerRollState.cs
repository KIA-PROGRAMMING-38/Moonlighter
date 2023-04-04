using UnityEngine;

public class PlayerRollState : PlayerAbilityState
{
    private Vector2 _rollDir;

    public PlayerRollState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        SetRollDirection();
        player.SetVelocity(_rollDir * playerData.RollingVelocity);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAnimationEnded)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    private void SetRollDirection()
    {
        if (stateMachine.PrevState == player.IdleState)
        {
            float moveX = player.Anim.GetFloat("MoveX");
            float moveY = player.Anim.GetFloat("MoveY");
            if (moveX == 1 && moveY == 0)
            {
                _rollDir = Vector2.right;
            }
            else if (moveX == -1 && moveY == 0)
            {
                _rollDir = Vector2.left;
            }
            else if (moveX == 0 && moveY == 1)
            {
                _rollDir = Vector2.up;
            }
            else if (moveX == 0 && moveY == -1)
            {
                _rollDir = Vector2.down;
            }
            else if (moveX != 0 && moveY > 0)
            {
                _rollDir = Vector2.up;
            }
            else if (moveX != 0 && moveY < 0)
            {
                _rollDir = Vector2.down;
            }
        }
        else if (stateMachine.PrevState == player.MoveState)
        {
            _rollDir = new Vector2(player.Anim.GetFloat("MoveX"), player.Anim.GetFloat("MoveY"));
        }
    }
}
