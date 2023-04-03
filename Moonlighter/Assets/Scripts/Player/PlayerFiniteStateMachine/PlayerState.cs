using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;

    protected Vector2 moveInput;

    protected float startTime;

    private string _animBoolName;

    public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        _animBoolName = animBoolName;
    }

    public virtual void Enter() 
    {
        DoChecks();
        player.Anim.SetBool(_animBoolName, true);
        startTime = Time.time;
    }

    public virtual void Exit()
    {
        player.Anim.SetBool(_animBoolName, false);
    }

    public virtual void LogicUpdate()
    {
        moveInput = player.InputHandler.MoveInput;
    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks() { }

}
