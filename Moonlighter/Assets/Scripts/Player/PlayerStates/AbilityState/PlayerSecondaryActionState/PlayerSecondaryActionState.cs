using EnumValue;
using UnityEngine;

public class PlayerSecondaryActionState : PlayerAbilityState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        player.CurrentState = PlayerStates.SecondaryAction;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rigid.velocity = inputHandler.MoveInput;

        LockRoll();

        LockAttack();

        if (false == inputHandler.SecondaryActionInput)
        {
            ChangeState(animator, PlayerStates.SecondaryAction, PlayerAnimParams.SECONDARYACTION, PlayerAnimParams.IDLE);
        }
        
        if (inputHandler.MoveInput == Vector2.zero)
        {
            ChangeState(animator, PlayerStates.SecondaryAction, PlayerAnimParams.SECONDARYACTION, PlayerAnimParams.ONSECONDARYACTION);
        }
    }
}
