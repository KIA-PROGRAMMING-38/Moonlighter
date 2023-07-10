using UnityEngine;

public class PlayerIdleState : PlayerState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        player.Rigid.velocity = Vector2.zero;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(input.MoveInput != Vector2.zero)
        {
            ExitCurrentState(PlayerAnimParameters.Idle);
            ChangeToNextState(PlayerAnimParameters.Move);
        }
        else if(input.RollInput)
        {
            ExitCurrentState(PlayerAnimParameters.Idle);
            ChangeToNextState(PlayerAnimParameters.Roll);
        }
    }
}
