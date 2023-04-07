using EnumValue;
using UnityEngine;

public class PlayerOnSecondaryActionState : PlayerAbilityState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        player.CurrentState = PlayerStates.OnSecondaryAction;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        LockRoll();

        LockAttack();

        if (false == inputHandler.SecondaryActionInput)
        {
            ChangeState(animator, PlayerStates.OnSecondaryAction, PlayerAnimParams.ONSECONDARYACTION, PlayerAnimParams.IDLE);
        }

        if (inputHandler.MoveInput != Vector2.zero)
        {
            ChangeState(animator, PlayerStates.OnSecondaryAction, PlayerAnimParams.ONSECONDARYACTION, PlayerAnimParams.SECONDARYACTION);
        }
    }



}
