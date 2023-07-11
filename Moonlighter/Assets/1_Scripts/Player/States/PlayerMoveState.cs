using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.SetFacingDirection();

        if(false == input.IsMoving)
        {
            ChangeNextState(PlayerAnimParameters.Move, PlayerAnimParameters.Idle);
        }
        else if (input.RollInput)
        {
            ChangeNextState(PlayerAnimParameters.Move, PlayerAnimParameters.Roll);
        }
        else
        {
            player.Anim.SetFloat(PlayerAnimParameters.MoveX, input.MoveInput.x);
            player.Anim.SetFloat(PlayerAnimParameters.MoveY, input.MoveInput.y);
            player.Rigid.velocity = input.MoveInput * player.Stat.MoveSpeed;
        }
    }
}