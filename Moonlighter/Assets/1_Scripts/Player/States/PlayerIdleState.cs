using UnityEngine;

public class PlayerIdleState : PlayerState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        player.Rigid.velocity = zeroVelocity;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(input.MoveInput != Vector2.zero)
        {
            ChangeNextState(PlayerAnimParameters.Idle, PlayerAnimParameters.Move);
        }
        else if (input.NormalAttackInput)
        {
            ChangeNextState(PlayerAnimParameters.Idle, PlayerAnimParameters.NormalAttack1);
        }
        else if(input.RollInput)
        {
            ChangeNextState(PlayerAnimParameters.Idle, PlayerAnimParameters.Roll);
        }
    }
}
