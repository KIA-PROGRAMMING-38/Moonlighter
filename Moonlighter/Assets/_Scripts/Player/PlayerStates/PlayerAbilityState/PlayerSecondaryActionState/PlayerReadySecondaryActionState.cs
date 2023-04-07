using EnumValue;
using UnityEngine;

public class PlayerReadySecondaryActionState : PlayerAbilityState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        enoughChargeTime = stateInfo.length * 0.95f;
        player.CurrentState = PlayerStates.ReadySecondaryAction;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        LockRoll();

        LockAttack();
        CheckEnoughChargeTime();
        if (isChargeOn)
        {
            if (inputHandler.SecondaryActionInput)
            {
                checkChargeTime = 0;
                ChangeState(animator, PlayerStates.ReadySecondaryAction, PlayerAnimParams.READYSECONDARYACTION, PlayerAnimParams.ONSECONDARYACTION);
            }
        }

        if (false == inputHandler.SecondaryActionInput)
        {
            ChangeState(animator, PlayerStates.ReadySecondaryAction, PlayerAnimParams.READYSECONDARYACTION, PlayerAnimParams.IDLE);
        }
    }
}
