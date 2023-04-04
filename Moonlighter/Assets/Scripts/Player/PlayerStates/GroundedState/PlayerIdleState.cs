using EnumValue;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        rigid.velocity = Vector2.zero;
        player.CurrentState = PlayerStates.Idle;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        
        if (inputHandler.MoveInput != Vector2.zero)
        {
            ChangeState(animator, PlayerStates.Idle, PlayerAnimParams.IDLE, PlayerAnimParams.MOVE);
        }
        else if (inputHandler.RollInput)
        {
            inputHandler.UseRollInput();
            ChangeState(animator, PlayerStates.Idle, PlayerAnimParams.IDLE, PlayerAnimParams.ROLL);
        }
    }
}
